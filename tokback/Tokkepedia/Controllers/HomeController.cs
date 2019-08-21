using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tokkepedia.Models;
using Tokkepedia.Models.ViewModels;
using Tokkepedia.Services;
using Tokkepedia.Services.Interfaces;
using Tokkepedia.Tools;
using Tokkepedia.Tools.Extensions;
using System.Drawing;

namespace Tokkepedia.Controllers
{
    public class HomeController : Controller
    {
        const string SessionTokGroupsKey = "TokGroups";
        const string SessionReactionsKey = "Reactions";

        const int MAX_CATEGORY_LENGTH = 50;

        private readonly UserManager<TokketUser> _userManager;
        private readonly IUserService _userService;
        private readonly ITokService _tokService;
        private readonly ICommonService _commonService;
        private readonly ISearchService _searchService;
        private readonly INotificationService _notificationService;
        private readonly IStickerService _stickerService;

        public HomeController(UserManager<TokketUser> userManager,
             IUserService userService,
             ITokService tokService,
             ICommonService commonService,
             ISearchService searchService,
             INotificationService notificationService,
             IStickerService stickerService)
        {
            _userManager = userManager;
            _userService = userService;
            _tokService = tokService;
            _commonService = commonService;
            _notificationService = notificationService;
            _searchService = searchService;
            _stickerService = stickerService;
        }

        [Route("all")]
        public async Task<IActionResult> All()
        {
            IndexViewModel vm = new IndexViewModel();
            var tokResult = await _tokService.GetToksAsync();
            vm.Tok = tokResult?.Results ?? new List<Tok>();

            var count = await _tokService.GetTokkepediaCounterAsync();
            vm.Toks = count.Toks ?? (long)0.00 - count.DeletedToks ?? (long)0.00;

            return View(vm);
        }

        [Route("featuredtoks")]
        public async Task<IActionResult> FeaturedToks()
        {
            IndexViewModel vm = new IndexViewModel();
            var tokResult = await _tokService.GetAllFeaturedToksAsync();
            vm.Tok = tokResult.Results;
            vm.Toks = tokResult.Results.Count;

            return View(vm);
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            IndexViewModel vm = new IndexViewModel();

            if (User != null)
            {
                var user = await _userManager.GetUserAsync(User);
                ViewBag.UserPhoto = User.Identity.IsAuthenticated ? user?.UserPhoto ?? string.Empty : string.Empty;
                vm.IsSignedIn = false;
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> GetTopCounter(int index = 0)
        {
            switch (index)
            {
                case 0: // Top Tok Types
                    return PartialView("Home/_TopTokTypes", (await _tokService.GetTopTokTypesWeekAsync()).Results);
                case 1: // Top Categories
                    return PartialView("Home/_TopCategories", (await _tokService.GetTopCategoriesWeekAsync()).Results);
                case 2: // Top Users
                    return PartialView("Home/_TopUsers", (await _tokService.GetTopUsersWeekAsync()).Results);
                default: // Default - Top Tok Types
                    return PartialView("Home/_TopTokTypes", (await _tokService.GetTopTokTypesWeekAsync()).Results);
            }
        }

        [Route("category")]
        public async Task<IActionResult> Category(string id)
        {
            CategoryViewModel vm = new CategoryViewModel();

            if (User != null)
            {
                vm.Category = await _tokService.GetCategoryAsync(id);
                if (vm.Category == null)
                    vm.Category = new Category() { Name = id, Id = id };

                if (string.IsNullOrEmpty(vm.Category.Name))
                    vm.Category.Name = vm.Category.Id;

                vm.Category.Name = vm.Category.Name.Replace("category-", "").FirstLetterToUpperCase();
            }

            return View(vm);
        }

        [Route("country")]
        public async Task<IActionResult> Country(string name)
        {
            CountryViewModel vm = new CountryViewModel();
            var user = await _userManager.GetUserAsync(User);
            var data = await _tokService.GetToksAsync(new TokQueryValues() { country = name });
            vm.Tok = data.Results;
            //TODO: Get Country Tok Count from database

            if (vm.Country == null)
                vm.Country = new Country() { Name = name };

            var toks = vm.Tok.ToArray();

            if (user != null)
            {
            }

            vm.Token = data.Token;

            return View(vm);

        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> Search(string text)
        {
            IndexViewModel vm = new IndexViewModel();

            var user = await _userManager.GetUserAsync(User);
            var data = await _tokService.GetToksAsync(new TokQueryValues() { text = text });
            vm.Tok = data.Results;
                
            vm.SearchText = text;

            var toks = vm.Tok.ToArray();

            if (user != null)
            {
                //Load Reactions, etc
            }

            vm.Token = data.Token;
            return View(vm);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories(string keyword = "")
        {
            var cats = await _commonService.SearchCategoriesAsync(keyword);
            return PartialView("Home/_AllCategoryViews", cats);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(string keyword = "")
        {
            var users = await _commonService.SearchUsersAsync(keyword);
            return PartialView("Home/_AllUserViews", users);
        }

        [HttpGet]
        public async Task<IActionResult> InitializeNotification()
        {
            var notifs = await _notificationService.GetNotificationsAsync(User.GetUserId());

            return PartialView("Home/_AllNotificationViews", notifs);
        }


        [HttpPost]
        public async Task<IActionResult> MarkAsRead(string id)
        {
            return Json(new { result = await _notificationService.MarkAsReadAsync(id) });
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveNotification(string[] ids)
        {
            return Json(new { result = await _notificationService.RemoveNotificationsAsync(ids) });
        }

        [HttpPost]
        public async Task<IActionResult> AddRecentSearch(string keyword)
        {
            return Json(await _commonService.AddRecentSearchAsync(keyword));
        }

        [HttpGet]
        public IActionResult GetRecentSearch(string keyword)
        {
            //return Json(await _commonService.GetRecentSearchesAsync());
            return Json(_searchService.GetSearchSuggestions(keyword));
        }

        [HttpGet]
        public IActionResult GetCountryStates(string countryId = "us")
        {
            return Json(CountryTool.GetCountryStates(countryId));
        }

        [HttpGet]
        public async Task<IActionResult> SearchToks(string keyword)
        {
            var res = await _searchService.GetSearchToks(keyword);
            var defaultToks = await this.RenderViewAsync("Tok/_TokContainer", res, true);
            return Json(defaultToks);
        }

        [Route("about")]
        public async Task<IActionResult> About()
        {
            return View();
        }

        [Route("avatars")]
        public async Task<IActionResult> Avatars()
        {
            return View(PurchasesTool.GetProducts());
        }

        [Route("stickers")]
        public async Task<IActionResult> Stickers()
        {
            return View(await _stickerService.GetStickersAsync());
        }

        [Route("shop")]
        public async Task<IActionResult> Shop()
        {
            var l = await _stickerService.GetStickersAsync();
            ViewBag.Stickers = l;
            return View(PurchasesTool.GetProducts());
        }

        [Route("privacy")]
        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [Route("terms")]
        public async Task<IActionResult> Terms()
        {
            return View();
        }

        [Route("support")]
        public async Task<IActionResult> Support()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
