using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tokkepedia.Models;
using Tokkepedia.Models.Accessory;
using Tokkepedia.Models.ViewModels;
using Tokkepedia.Services;
using Tokkepedia.Services.Interfaces;
using Tokkepedia.Tools;
using Tokkepedia.Tools.Extensions;
using Tokkepedia.Tools.Helpers;

namespace Tokkepedia.Controllers
{
    public class TokController : Controller
    {
        const string SessionTokGroupsKey = "TokGroups";
        const int MAX_CATEGORY_LENGTH = 50;

        private readonly UserManager<TokketUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IUserService _userService;
        private readonly ITokService _tokService;
        private readonly IReactionService _reactionService;
        private readonly ISetService _setService;
        private readonly IStickerService _stickerService;

        public TokController(UserManager<TokketUser> userManager,
            IHostingEnvironment hostingEnvironment,
             IUserService userService,
             ITokService tokService,
             IReactionService reactionService,
             ISetService setService,
             IStickerService stickerService)
        {
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            _tokService = tokService;
            _reactionService = reactionService;
            _setService = setService;
            _stickerService = stickerService;
        }

        [Route("toktype")]
        public async Task<IActionResult> TokType(string id)
        {
            TokTypeViewModel vm = new TokTypeViewModel();
            id = id?.ToLower();

            List<TokTypeList> groups;
            if (HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey) == null)
            {
                var g = await _tokService.GetTokGroupsAsync();
                HttpContext.Session.Set<List<TokTypeList>>(SessionTokGroupsKey, g);
                groups = g;
            }
            else
            {
                groups = HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey);
            }

            TokTypeList selectedGroup;
            TokType selectedType;
            if (User != null)
            {
                //Get Type
                for (int i = 0; i < groups.Count; ++i)
                {
                    if (groups[i] != null)
                    {
                        if (groups[i].TokTypeIds != null)
                        {
                            List<string> typelist = new List<string>();

                            foreach (var type in groups[i].TokTypeIds)
                                typelist.Add(type.ToLower());

                            groups[i].TokTypeIds = typelist.ToArray();
                        }
                        else
                        {
                            groups[i].TokTypeIds = new string[] { "" };
                        }
                    }
                }

                if (groups != null)
                    selectedGroup = groups.FirstOrDefault(x => x.TokTypeIds.Contains(id));
                else
                    selectedGroup = null;

                var typeIndex = selectedGroup.TokTypeIds.ToList().IndexOf(id);

                selectedType = new TokType()
                {
                    Id = id,
                    Name = selectedGroup.TokTypes[typeIndex],
                    Description = selectedGroup.Descriptions[typeIndex],
                    Example = selectedGroup.Examples[typeIndex]
                };
                if (vm.TokType == null)
                {
                    vm.TokType = selectedType;
                }
                else
                {
                    vm.TokType.Description = selectedType.Description;
                    vm.TokType.Example = selectedType.Example;
                }

                var user = await _userManager.GetUserAsync(User);
                //var data = await apiClient.GetToksAsync(new TokQueryValues() { toktype = selectedType.Name });
                //vm.Tok = data.Results;


                var selectedGroupCounter = await _tokService.GetTokGroupCounterAsync($"toktypelistcounter-{selectedGroup.TokGroup.ToIdFormat()}");
                var index = Array.IndexOf(selectedGroupCounter.TokTypeIds, selectedType.Id);
                var count = selectedGroupCounter.TokTypeCounts[index];
                vm.TokType.Toks = count;

                var toks = vm.Tok?.ToArray();


                if (user != null)
                {
                    //Reactions
                }

                //vm.Token = data.Token;
            }
            return View(vm);
        }

        [Route("tok")]
        [ActionName("TokInfo")]
        public async Task<IActionResult> TokInfo(string id)
        {
            TokInfoViewModel viewModel = new TokInfoViewModel();
            var user = await _userManager.GetUserAsync(User);
            ViewBag.UserPhoto = User.Identity.IsAuthenticated ? user?.UserPhoto ?? string.Empty : string.Empty;
            viewModel.Tok = await _tokService.GetTokAsync(id);

            if (HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey) == null)
            {
                var g = await _tokService.GetTokGroupsAsync();
                HttpContext.Session.Set<List<TokTypeList>>(SessionTokGroupsKey, g);
                viewModel.TokGroups = g;
            }
            else
            {
                viewModel.TokGroups = HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey);
            }
            var group = viewModel.TokGroups.SingleOrDefault(x => x.TokGroup == viewModel.Tok.TokGroup);
            viewModel.Tok.OptionalFields = group.OptionalFields;
            viewModel.Tok.RequiredFields = group.RequiredFields;

            if (viewModel.Tok.OptionalFieldValues == null)
                viewModel.Tok.OptionalFieldValues = new string[group.OptionalFields.Length];
            if (viewModel.Tok.OptionalFieldValues.Length != group.OptionalFields.Length)
                viewModel.Tok.OptionalFieldValues = new string[group.OptionalFields.Length];

            if (viewModel.Tok.RequiredFieldValues == null)
                viewModel.Tok.RequiredFieldValues = new string[group.RequiredFields.Length];
            if (viewModel.Tok.RequiredFieldValues.Length != group.RequiredFields.Length)
                viewModel.Tok.RequiredFieldValues = new string[group.RequiredFields.Length];

            //var data = await apiClient.GetCommentsAsync(id, new TokQueryValues() { itemid = id });
            //viewModel.Comments = data.Results;
            //viewModel.Token = data.Token;
            return View(viewModel);
        }

        [Route("reactions")]
        [ActionName("TokReactions")]
        public async Task<IActionResult> TokReactions(string id)
        {
            TokReactionsViewModel viewModel = new TokReactionsViewModel();
            viewModel.Tok = await _tokService.GetTokAsync(id);

            var res = await _reactionService.GetReactionsAsync(new ReactionQueryValues() { item_id = viewModel.Tok.Id, activity_id = viewModel.Tok.ActivityId });
            if (res != null) viewModel.Reactions = res.Results;
            else viewModel.Reactions = new List<TokkepediaReaction>();

            return View(viewModel);
        }

        [Route("detailreactions")]
        [ActionName("TokDetailReactions")]
        public async Task<IActionResult> TokDetailReactions(string id, string detailNum)
        {
            TokReactionsViewModel viewModel = new TokReactionsViewModel();

            //TODO: Get Detail Reactions

            return View(viewModel);
        }

        [Authorize]
        [Route("addtok")]
        [ActionName("AddTok")]
        public async Task<IActionResult> AddTok()
        {
            AddTokViewModel vm = new AddTokViewModel();

            //Noncached mode
            //var groups = await apiClient.GetTokGroupsAsync(); 
            //HttpContext.Session.Set<List<TokTypeList>>(SessionTokGroupsKey, groups);
            //vm.TokGroups = groups;

            List<TokTypeList> groups;
            if (HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey) == null)
            {
                groups = await _tokService.GetTokGroupsAsync();
                HttpContext.Session.Set<List<TokTypeList>>(SessionTokGroupsKey, groups);
                vm.TokGroups = groups;
            }
            else
            {
                vm.TokGroups = HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey);
            }

            vm.TokGroupDataString = JsonConvert.SerializeObject(vm.TokGroups);


            return View(vm);
        }

        [HttpPost]
        [Authorize]
        [Route("addtok")]
        [ActionName("AddTok")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddTok([Bind("Tok,TokGroupDataString,Base64Image")] AddTokViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                #region Make sure Category is not in certain fields
                bool categoryFound = false;
                List<string> foundLocation = new List<string>();
                //Category cannot be in Primary Secondary Type or Details
                //if (viewModel.Tok.TokType.ToLower().Contains(viewModel.Tok.Category.ToLower()))
                //{
                //    categoryFound = true;
                //    foundLocation.Add("Tok.TokType");
                //}

                //if (viewModel.Tok.PrimaryFieldText.ToLower().Contains(viewModel.Tok.Category.ToLower()))
                //{
                //    categoryFound = true;
                //    foundLocation.Add("Tok.PrimaryFieldText");
                //}

                //if (viewModel.Tok.IsDetailBased)
                //{
                //    for (int i = 0; i < viewModel.Tok.Details.Length; ++i)
                //    {
                //        if (viewModel.Tok.Details[i].ToLower().Contains(viewModel.Tok.Category.ToLower()))
                //        {
                //            categoryFound = true;
                //            foundLocation.Add($"Tok.Details[{i}]");
                //        }
                //    }
                //}
                //else
                //{
                //    if (viewModel.Tok.SecondaryFieldText.ToLower().Contains(viewModel.Tok.Category.ToLower()))
                //    {
                //        categoryFound = true;
                //        foundLocation.Add("Tok.SecondaryFieldText");
                //    }
                //}

                //if (categoryFound)
                //{
                //    //foreach (var m in foundLocation)
                //    //    ModelState.AddModelError(m, $"{m} should not contain the category.");

                //    return View(viewModel);
                //}
                #endregion
                var groups = JsonConvert.DeserializeObject<List<TokTypeList>>(viewModel.TokGroupDataString);
                var selectedGroup = groups.Find(x => x.TokGroup == viewModel.Tok.TokGroup);

                if (selectedGroup != null)
                {
                    viewModel.Tok.PrimaryFieldLimit = selectedGroup.PrimaryCharLimit;
                    viewModel.Tok.SecondaryFieldLimit = selectedGroup.SecondaryCharLimit;
                    viewModel.Tok.OptionalFields = selectedGroup.OptionalFields;
                }

                var user = await _userManager.GetUserAsync(User);
                user.IdToken = User.GetToken();

                //User data
                viewModel.Tok.UserDisplayName = user.DisplayName;
                viewModel.Tok.UserId = user.Id;
                viewModel.Tok.UserCountry = user.Country;
                viewModel.Tok.UserPhoto = user.UserPhoto;

                //Image Upload
                if (!string.IsNullOrEmpty(viewModel.Base64Image))
                {
                    viewModel.Tok.Image = viewModel.Base64Image;
                }

                viewModel.Tok.CategoryId = "category-" + viewModel.Tok.Category?.ToIdFormat();
                viewModel.Tok.TokTypeId = $"toktype-{viewModel.Tok.TokGroup?.ToIdFormat()}-{viewModel.Tok.TokType?.ToIdFormat()}";
                if (viewModel.Tok.IsEnglish) { viewModel.Tok.Language = "english"; }

                //TO-DO: User Info


                await _tokService.CreateTokAsync(viewModel.Tok);
            }
            else
            {
                // If we got this far, something failed, redisplay form
                return View(viewModel);
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("addmultipletoks")]
        [ActionName("AddMultipleToks")]
        public async Task<IActionResult> AddMultipleToks()
        {
            AddMultipleToksViewModel vm = new AddMultipleToksViewModel();
            vm.TokGroups = await _tokService.GetTokGroupsAsync();
            vm.TokGroupStrings = vm.TokGroups.Select(x => x.TokGroup?.ToLower()).ToArray();
            vm.TokGroupString = String.Join("|", vm.TokGroupStrings); //JsonConvert.SerializeObject(
            vm.TokGroupDataString = JsonConvert.SerializeObject(vm.TokGroups);

            return RedirectToAction("Index", "Home");
            //return View(vm);
        }

        [HttpPost]
        [Route("addmultipletoks")]
        [ActionName("AddMultipleToks")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMultipleToks([Bind("Toks,TokGroupDataString")] AddMultipleToksViewModel viewModel)
        {
            var groups = JsonConvert.DeserializeObject<List<TokTypeList>>(viewModel.TokGroupDataString);
            var table = JsonConvert.DeserializeObject<string[][]>(viewModel.Toks);
            var user = await _userManager.GetUserAsync(User);

            List<Tok> TokList = new List<Tok>();
            foreach (var tokElement in table)
            {
                //Extra validation
                //Category
                if (tokElement[2].Length <= MAX_CATEGORY_LENGTH && !String.IsNullOrEmpty(tokElement[0]) && !String.IsNullOrEmpty(tokElement[1]))
                {
                    //Tok Group
                    var selectedGroup = groups.Find(x => x.TokGroup.ToLower() == tokElement[0]);
                    if (selectedGroup != null)
                    {
                        //Tok Type
                        var selectedType = selectedGroup.TokTypes.FirstOrDefault(x => x.ToLower() == tokElement[1]);
                        if (selectedType != null)
                        {
                            //Primary Field
                            if (tokElement[3].Length <= selectedGroup.PrimaryCharLimit && !String.IsNullOrEmpty(tokElement[3]))
                            {
                                //Secondary/Detailed
                                if (!selectedGroup.IsDetailBased)
                                {
                                    if (tokElement[4].Length <= selectedGroup.SecondaryCharLimit && !String.IsNullOrEmpty(tokElement[4]))
                                    {
                                        Tok t = new Tok()
                                        {
                                            TokGroup = selectedGroup.TokGroup,//tokElement[0],
                                            TokType = selectedType,//tokElement[1],
                                            Category = tokElement[2],
                                            CategoryId = "category-" + tokElement[2]?.ToIdFormat(),
                                            PrimaryFieldText = tokElement[3],
                                            SecondaryFieldText = tokElement[4],
                                            PrimaryFieldName = selectedGroup.PrimaryFieldName,
                                            SecondaryFieldName = selectedGroup.SecondaryFieldName,
                                            TokTypeId = $"toktype-{tokElement[0]?.ToIdFormat()}-{tokElement[1]?.ToIdFormat()}",
                                            IsDetailBased = false,
                                            IsEnglish = true,
                                            Language = "english"
                                        };
                                        //User data
                                        t.UserDisplayName = user.UserName;
                                        t.UserId = user.Id;

                                        TokList.Add(t);
                                    }
                                }
                                else
                                {
                                    if (!String.IsNullOrEmpty(tokElement[5]) && !String.IsNullOrEmpty(tokElement[6]) && !String.IsNullOrEmpty(tokElement[7]) &&
                                        tokElement[5].Length <= selectedGroup.SecondaryCharLimit && tokElement[6].Length <= selectedGroup.SecondaryCharLimit && tokElement[7].Length <= selectedGroup.SecondaryCharLimit &&
                                        tokElement[8].Length <= selectedGroup.SecondaryCharLimit && tokElement[9].Length <= selectedGroup.SecondaryCharLimit)
                                    {
                                        Tok t = new Tok()
                                        {
                                            TokGroup = selectedGroup.TokGroup,//tokElement[0],
                                            TokType = selectedType,//tokElement[1],
                                            Category = tokElement[2],

                                            PrimaryFieldText = tokElement[3],
                                            Details = new string[] { tokElement[5], tokElement[6], tokElement[7], tokElement[8], tokElement[9] },
                                            PrimaryFieldName = selectedGroup.PrimaryFieldName,
                                            SecondaryFieldName = selectedGroup.SecondaryFieldName,
                                            TokTypeId = $"toktype-{tokElement[0]?.ToIdFormat()}-{tokElement[1]?.ToIdFormat()}",
                                            IsDetailBased = true,
                                            IsEnglish = true,
                                            Language = "english"
                                        };
                                        //User data
                                        t.UserDisplayName = user.UserName;
                                        t.UserId = user.Id;

                                        TokList.Add(t);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //Add data to Toks

            //Send data to database
            foreach (var tok in TokList)
            {
                await _tokService.CreateTokAsync(tok);
            }

            return View();
        }

        [Route("toktypes")]
        public IActionResult TokTypes()
        {
            return View();
        }

        [Route("toktypescounts")]
        public IActionResult TokTypeCounts()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> InitializeTokTypes(bool isNew = false)
        {
            BrowseViewModel vm = new BrowseViewModel();

            if (HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey) == null)
            {
                var g = await _tokService.GetTokGroupsAsync();
                HttpContext.Session.Set<List<TokTypeList>>(SessionTokGroupsKey, g);
                vm.TokGroups = g;
            }
            else
            {
                vm.TokGroups = HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey);
            }

            List<TokTypeList> groups = new List<TokTypeList>();
            foreach (var group in vm.TokGroups)
            {
                groups.Add(group);
            }
            groups = groups.OrderBy(x => x.TokTypes.Count()).ToList();

            vm.TokGroups = groups;

            //Counters
            vm.Counters = await _tokService.GetTokGroupCountersAsync();

            List<TokTypeListCounter> counters = new List<TokTypeListCounter>();
            foreach (var counter in vm.Counters)
            {
                counters.Add(counter);
            }
            counters = counters.OrderBy(x => x.TokTypes.Count()).ToList();

            vm.Counters = counters;


            //Tok Types in alphabetical order logic
            List<List<(string, int, string)>> listOfLists = new List<List<(string, int, string)>>();

            for (int i = 0; i < vm.Counters.Count; ++i)
            {
                List<(string, int, string)> listTuple = new List<(string, int, string)>();
                for (int j = 0; j < vm.Counters[i].TokTypes.Length; ++j)
                {
                    listTuple.Add((vm.Counters[i].TokTypes[j], vm.Counters[i].TokTypeCounts[j], vm.Counters[i].TokTypeIds[j]));
                }
                listTuple = listTuple.OrderBy(x => x.Item1).ToList(); //Alpha
                listOfLists.Add(listTuple);
            }

            for (int i = 0; i < vm.Counters.Count; ++i)
            {
                vm.Counters[i].TokTypes = listOfLists[i].Select(x => x.Item1).ToArray();
                vm.TokGroups[i].TokTypes = listOfLists[i].Select(x => x.Item1).ToArray();
                vm.Counters[i].TokTypeCounts = listOfLists[i].Select(x => x.Item2).ToArray();
                vm.Counters[i].TokTypeIds = listOfLists[i].Select(x => x.Item3).ToArray();
                vm.TokGroups[i].TokTypeIds = listOfLists[i].Select(x => x.Item3).ToArray();
            }

            if (isNew) return PartialView("Tok/_TokTypesNewContent", vm);
            else return PartialView("Tok/_TokTypesContent", vm);
        }

        [HttpPost]
        [ActionName("GetSubtypes")]
        public JsonResult GetSubtypes([FromBody] GroupBind g)
        {
            var tokgroup = JsonConvert.DeserializeObject<TokTypeList>(g.group);
            return Json(tokgroup);
        }

        #region Tok Actions
        [HttpPost]
        [ActionName("ReportTok")]
        public async Task<JsonResult> ReportTok([FromBody] GroupBind id)
        {
            try
            {
                var item = JsonConvert.DeserializeObject<Report>(id.group);
                item.ItemId = item.Id;
                item.Id = "report-" + Guid.NewGuid().ToString("n");
                item.Message = id.comment;
                item.CreatedTime = DateTime.Now;
                item.Label = "report";
                item.PartitionKey = item.Id;

                await _tokService.CreateReportAsync(item);
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json("");
        }

        [HttpPost]
        [ActionName("Replicate")]
        public async Task<JsonResult> Replicate([FromBody] GroupBind id)
        {
            var tok = JsonConvert.DeserializeObject<Tok>(id.group);
            tok.IsReplicated = true;
            tok.Id = "";
            tok.CreatedTime = DateTime.Now;
            try
            {
                await _tokService.CreateTokAsync(tok);
            }
            catch (Exception ex)
            {
                return null;
            }
            return Json(""); //return null;
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<JsonResult> Edit([FromBody] GroupBind id)
        {
            try
            {
                var tok = JsonConvert.DeserializeObject<Tok>(id.group);
                await _tokService.UpdateTokAsync(tok);
                return Json(""); //return null;
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<JsonResult> Delete([FromBody] GroupBind id)
        {
            string e = "";
            try
            {
                await _tokService.DeleteTokAsync(id.group);

                //No need to delete comments
            }
            catch (Exception ex)
            {
                e = ex.Message;
                return null;
            }
            return Json(e); //return null;
        }
        #endregion

        [HttpGet]
        public async Task<ActionResult> InitializeRawTokData(string filter = "", FilterType type = FilterType.None)
        {
            ResultData<Tok> tokResult = new ResultData<Tok>();
            tokResult.Results = new List<Tok>();

            string strtoken = "";
            if (User.Identity.IsAuthenticated)
                strtoken = User.GetStreamToken();

            switch (type)
            {
                case FilterType.None:
                    if (User.Identity.IsAuthenticated)
                        tokResult = await _tokService.GetToksAsync(new TokQueryValues() { streamtoken = strtoken });
                    else
                        tokResult = await _tokService.GetFeaturedToksAsync();
                    break;
                case FilterType.TokType:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { toktype = filter, streamtoken = strtoken });
                    break;
                case FilterType.Text:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { text = filter, streamtoken = strtoken });
                    break;
                case FilterType.Category:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { category = filter, streamtoken = strtoken });
                    break;
                case FilterType.Country:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { country = filter, streamtoken = strtoken });
                    break;
                case FilterType.User:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { userid = filter, streamtoken = strtoken });
                    break;
                case FilterType.Group:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { tokgroup = filter, streamtoken = strtoken });
                    break;
                case FilterType.Featured:
                    tokResult = await _tokService.GetAllFeaturedToksAsync();
                    break;
                case FilterType.All:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { streamtoken = strtoken });
                    break;
                default:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { streamtoken = strtoken });
                    break;
            }

            var toksWithSticker = new List<Tok>();
            foreach (var tok in tokResult?.Results ?? new List<Tok>())
            {
                var sticker = StickersTool.Stickers.FirstOrDefault(x => x.Id == (string.IsNullOrEmpty(tok.Sticker) ? tok.Sticker : tok.Sticker.Split("-")[0]));
                tok.StickerImage = sticker?.Image ?? string.Empty;
                toksWithSticker.Add(tok);
            }

            return Json(new
            {
                token = tokResult?.Token ?? string.Empty,
                allToks = toksWithSticker
            });
        }

        [HttpGet]
        public async Task<ActionResult> InitializeTokData(string filter = "", FilterType type = FilterType.None, bool withCardView = false)
        {
            ResultData<Tok> tokResult = new ResultData<Tok>();
            tokResult.Results = new List<Tok>();

            string strtoken = "";
            if (User.Identity.IsAuthenticated)
                strtoken = User.GetStreamToken();

            switch (type)
            {
                case FilterType.None:
                    if (User.Identity.IsAuthenticated)
                        tokResult = await _tokService.GetToksAsync(new TokQueryValues() { streamtoken = strtoken });
                    else
                        tokResult = await _tokService.GetFeaturedToksAsync();
                    break;
                case FilterType.TokType:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { toktype = filter, streamtoken = strtoken });
                    break;
                case FilterType.Text:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { text = filter, streamtoken = strtoken });
                    break;
                case FilterType.Category:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { category = filter, streamtoken = strtoken });
                    break;
                case FilterType.Country:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { country = filter, streamtoken = strtoken });
                    break;
                case FilterType.User:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { userid = filter, streamtoken = strtoken });
                    break;
                case FilterType.Group:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { tokgroup = filter, streamtoken = strtoken });
                    break;
                case FilterType.Featured:
                    tokResult = await _tokService.GetAllFeaturedToksAsync();
                    break;
                case FilterType.All:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { streamtoken = strtoken });
                    break;
                default:
                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { streamtoken = strtoken });
                    break;
            }

            var cardViews = "";
            if (withCardView) cardViews = await this.RenderViewAsync("Tok/_TokCardContainer", tokResult, true);
            var defaultToks = await this.RenderViewAsync("Tok/_TokContainer", tokResult, true);
            var tokLists = await this.RenderViewAsync("Tok/_TokListContainer", tokResult, true);

            return Json(new {
                token = tokResult?.Token ?? string.Empty,
                cardHtml = cardViews,
                defaultTokHtml = defaultToks,
                tokListHtml = tokLists
            });
        }

        #region Loads more toks when scrolled to bottom
        [HttpPost]
        public async Task<ActionResult> GetData([FromBody] GroupBind token)
        {
            if (String.IsNullOrEmpty(token.group)) return Json(null);
            ResultData<Tok> data;
            data = await _tokService.GetToksAsync(new TokQueryValues() { token = token.group, loadmore = "yes" });
            return Json(data);
        }

        [HttpPost]
        public async Task<ActionResult> GetSearchData([FromBody] GroupBind token)
        {
            ResultData<Tok> data = new ResultData<Tok>() { Results = new List<Tok>(), Token = string.Empty };
            if (token != null)
            {
                TokQueryValues values = new TokQueryValues()
                {
                    text = token.comment,
                    country = token.country,
                    category = token.category,
                    toktype = token.toktypeid,
                    tokgroup = token.tokgroup,
                    userid = token.userid,
                    order = token.order,
                    loadmore = token.isLoadMore,
                    token = token.group
                };

                if (token.loadCount <= 1)
                {
                    data = await _tokService.GetToksAsync();
                }
                else
                    data = await _tokService.GetToksAsync(values);
            }

            return Json(data);
        }
        #endregion

        [HttpPost]
        [ActionName("AddTokToSet")]
        public async Task<JsonResult> AddTokToSet([FromBody] GroupBind id)
        {
            var setId = id.group;
            var setUserId = id.userid;
            var tokId = id.comment;

            try
            {
                var tok = await _setService.AddTokToSetAsync(setId, setUserId, tokId);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RenderTok([FromBody] GroupBind id)
        {
            List<string> Colors = new List<string>() {
                "#d32f2f", "#C2185B", "#7B1FA2", "#512DA8",
                "#303F9F", "#1976D2", "#0288D1", "#0097A7",
                "#00796B", "#388E3C", "#689F38", "#AFB42B",
                "#FBC02D", "#FFA000", "#F57C00", "#E64A19"
                };
            var rndmColors = Colors.Shuffle();
            int idx = 0;
            var toks = JsonConvert.DeserializeObject<Tok[]>(id.group);

            string tokView = string.Empty, cardView = string.Empty, tileView = string.Empty;
            foreach (var tok in toks)
            {
                try
                {
                    if (tok != null)
                    {
                        if (idx >= Colors.Count) { rndmColors = Colors.Shuffle(); idx = 0; } // Shuffle Again
                        tok.ColorHex = rndmColors[idx];
                        idx += 1;

                        cardView += await this.RenderViewAsync("Tok/_TokCardView", tok, true);
                        tokView += await this.RenderViewAsync("TokView", tok, true);
                        tileView += await this.RenderViewAsync("Tok/_TokTileView", tok, true);
                    }
                    tokView += "<hr/>";
                }
                catch (Exception ex)
                {
                    //view = ex.Message;
                    break;
                }

            }

            return Json(new { cnt = toks.Count(), tokHtml = tokView, cardHtml = cardView, tileHtml = tileView });
        }

        [HttpPost]
        public async Task<IActionResult> RenderTokViews([FromBody] Tok tok)
        {
            List<string> Colors = new List<string>() {
                "#d32f2f", "#C2185B", "#7B1FA2", "#512DA8",
                "#303F9F", "#1976D2", "#0288D1", "#0097A7",
                "#00796B", "#388E3C", "#689F38", "#AFB42B",
                "#FBC02D", "#FFA000", "#F57C00", "#E64A19"
                };
            var rndmColors = Colors.Shuffle();
            tok.ColorHex = rndmColors[0];
            string tokHtml = (await this.RenderViewAsync("TokView", tok, true)) + "<hr style='width: 100%;padding: 6px 0px;' />";
            string tileHtml = await this.RenderViewAsync("Tok/_TokTileView", tok, true);
            string cardHtml = await this.RenderViewAsync("Tok/_TokCardView", tok, true);
            return Json(new { tokHtml, cardHtml, tileHtml });
        }

        [Route("tokgroup")]
        [HttpGet]
        public async Task<IActionResult> TokGroup(string name)
        {
            TokGroupViewModel vm = new TokGroupViewModel();

            List<TokTypeList> groups;

            if (HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey) == null)
            {
                var g = await _tokService.GetTokGroupsAsync();
                HttpContext.Session.Set<List<TokTypeList>>(SessionTokGroupsKey, g);
                groups = g;
            }
            else
            {
                groups = HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey);
            }

            TokTypeList selectedGroup;
            if (groups != null)
                selectedGroup = groups.FirstOrDefault(x => x.TokGroup.ToIdFormat() == name.ToIdFormat());
            else
                selectedGroup = null;

            if (selectedGroup != null)
            {
                var selectedGroupCounter = await _tokService.GetTokGroupCounterAsync($"toktypelistcounter-{selectedGroup.TokGroup.ToIdFormat()}");
                vm.Toks = selectedGroupCounter.TokTypeCounts.Sum();
                vm.TokGroup = selectedGroup;
            }

            return View(vm);
        }

        [Route("tokmatch")]
        [HttpGet]
        public async Task<IActionResult> TokMatch(string id = "", FilterType type = FilterType.None, int cnt = 0)
        {
            ResultData<Tok> tokResult = new ResultData<Tok>();
            tokResult.Results = new List<Tok>();
            var list = new List<Tok>();
            var totalCards = 0;
            string strtoken = string.Empty, pagetoken = string.Empty;
            if (User.Identity.IsAuthenticated)
                strtoken = User.GetStreamToken();

            if (!string.IsNullOrEmpty(id))
            {
                switch (type)
                {
                    case FilterType.Category:
                        for (int i = 0; i <= cnt; i++)
                        {
                            if (string.IsNullOrEmpty(pagetoken))
                                tokResult = await _tokService.GetToksAsync(new TokQueryValues() { category = id, streamtoken = strtoken });
                            else
                                tokResult = await _tokService.GetToksAsync(new TokQueryValues() { category = id, loadmore = "yes", token = pagetoken, order = "newest" });

                            pagetoken = tokResult.Token;
                            list.AddRange(tokResult.Results);
                        }
                        totalCards = list.Count;
                        break;
                    case FilterType.TokType:
                        for (int i = 0; i <= cnt; i++)
                        {
                            if (string.IsNullOrEmpty(pagetoken))
                                tokResult = await _tokService.GetToksAsync(new TokQueryValues() { toktype = id, streamtoken = strtoken });
                            else
                                tokResult = await _tokService.GetToksAsync(new TokQueryValues() { toktype = id, loadmore = "yes", token = pagetoken, order = "newest" });

                            pagetoken = tokResult.Token;
                            list.AddRange(tokResult.Results);
                        }
                        totalCards = list.Count;
                        break;
                    case FilterType.Set:
                        var item = await _setService.GetSetAsync(id);
                        foreach (var tok in item.TokIds)
                        {
                            var tokRes = await _tokService.GetTokAsync(tok);
                            if (tokRes != null)
                                list.Add(tokRes);
                        }
                        tokResult.Results = list;
                        totalCards = list.Count;
                        break;
                    case FilterType.None:
                    default:
                        var res = await _tokService.GetAllFeaturedToksAsync();
                        tokResult.Results = res.Results;
                        totalCards = res.Results.Count;
                        break;
                }
            }
            else
            {
                var res = await _tokService.GetAllFeaturedToksAsync();
                tokResult.Results = res.Results;
                totalCards = res.Results.Count;
            }

            dynamic resCards = GetCardRounds(totalCards);
            int rounds = (int)resCards.Rounds, divBy = (int)resCards.DivisibleBy;

            ViewBag.TotalCards = totalCards;
            ViewBag.MaxRound = rounds;
            ViewBag.Id = id;
            ViewBag.DataType = (int)type;
            ViewBag.DataCounter = cnt;
            ViewBag.OfflineToks = tokResult.Results;

            return View();
        }

        [HttpGet]
        public IActionResult GetRounds(int totalCards) => Json(GetCardRounds(totalCards));

        [HttpGet]
        public async Task<IActionResult> GetTokMatchRound(int round, string id, FilterType type = FilterType.None, int cnt = 0)
        {
            var invalidCards = new List<int> { 13, 25, 37, 49, 61, 73, 85, 97 };
            ResultData<Tok> tokResult = new ResultData<Tok>();
            tokResult.Results = new List<Tok>();
            var tempToks = new List<Tok>();
            string strtoken = string.Empty, pagetoken = string.Empty;
            if (User.Identity.IsAuthenticated)
                strtoken = User.GetStreamToken();

            switch (type)
            {
                case FilterType.Category:
                    for (int i = 0; i <= cnt; i++)
                    {
                        if (string.IsNullOrEmpty(pagetoken))
                            tokResult = await _tokService.GetToksAsync(new TokQueryValues() { category = id, streamtoken = strtoken });
                        else
                            tokResult = await _tokService.GetToksAsync(new TokQueryValues() { category = id, loadmore = "yes", token = pagetoken, order = "newest" });

                        pagetoken = tokResult.Token;
                        tempToks.AddRange(tokResult.Results);
                    }
                    break;
                case FilterType.TokType:
                    for (int i = 0; i <= cnt; i++)
                    {
                        if (string.IsNullOrEmpty(pagetoken))
                            tokResult = await _tokService.GetToksAsync(new TokQueryValues() { toktype = id, streamtoken = strtoken });
                        else
                            tokResult = await _tokService.GetToksAsync(new TokQueryValues() { toktype = id, loadmore = "yes", token = pagetoken, order = "newest" });

                        pagetoken = tokResult.Token;
                        tempToks.AddRange(tokResult.Results);
                    }
                    break;
                case FilterType.Set:
                    var item = await _setService.GetSetAsync(id);
                    foreach (var tok in item.TokIds)
                    {
                        var tokRes = await _tokService.GetTokAsync(tok);
                        if (tokRes != null)
                            tempToks.Add(tokRes);
                    }
                    break;
                case FilterType.Featured:
                case FilterType.None:
                default:
                    tokResult = await _tokService.GetFeaturedToksAsync();
                    tempToks.AddRange(tokResult.Results);
                    break;
            }

            //var res = tokResult;
            var totalCards = tempToks.Count;
            dynamic resCards = GetCardRounds(totalCards);
            int takeCnt = 0, rounds = (int)resCards.Rounds, divBy = (int)resCards.DivisibleBy;

            ViewBag.CurrentRound = round; // Set the current round

            if (round >= rounds - 1 && round <= rounds) // Before last round and last round
            {
                // If invalid cards
                switch (totalCards)
                {
                    case 13: // Invalid Numbers
                    case 25:
                    case 37:
                    case 49:
                    case 61:
                    case 73:
                    case 85:
                    case 97:
                        if (round == rounds) takeCnt = (totalCards % divBy) + 1; // Last round
                        else takeCnt = divBy - 1; // Before the last round
                        break;
                    default:
                        if (round == rounds && totalCards > 5) takeCnt = (totalCards % divBy); // Last round
                        else takeCnt = divBy; // Before the last round
                        break;
                }
            }
            else
                takeCnt = divBy;

            return PartialView("Tok/_TokMatchCardContainer", tempToks.Skip((((round * divBy) - divBy) + takeCnt) - takeCnt).Take(takeCnt).ToList().Shuffle());
        }

        [HttpPost]
        public async Task<IActionResult> GetTokMatchRound(List<Tok> toks, int round)
        {
            var invalidCards = new List<int> { 13, 25, 37, 49, 61, 73, 85, 97 };
            var tempToks = toks ?? new List<Tok>();

            var totalCards = tempToks.Count;
            dynamic resCards = GetCardRounds(totalCards);
            int takeCnt = 0, rounds = (int)resCards.Rounds, divBy = (int)resCards.DivisibleBy;

            ViewBag.CurrentRound = round; // Set the current round

            if (round >= rounds - 1 && round <= rounds) // Before last round and last round
            {
                // If invalid cards
                switch (totalCards)
                {
                    case 13: // Invalid Numbers
                    case 25:
                    case 37:
                    case 49:
                    case 61:
                    case 73:
                    case 85:
                    case 97:
                        if (round == rounds) takeCnt = (totalCards % divBy) + 1; // Last round
                        else takeCnt = divBy - 1; // Before the last round
                        break;
                    default:
                        if (round == rounds && totalCards > 5) takeCnt = (totalCards % divBy); // Last round
                        else takeCnt = divBy; // Before the last round
                        break;
                }
            }
            else
                takeCnt = divBy;

            return PartialView("Tok/_TokMatchCardContainer", tempToks.Skip((((round * divBy) - divBy) + takeCnt) - takeCnt).Take(takeCnt).ToList().Shuffle());
        }

        private dynamic GetCardRounds(int totalCards)
        {
            var rnd = 0;
            bool isValid = false;

            // If total cards is below 5
            if (totalCards < 5) return new { Rounds = 1, DivisibleBy = totalCards };

            for (int i = 4; i >= 2; i--)
            {
                int rem = (totalCards % i);

                int initial = int.Parse(Math.Truncate((decimal)totalCards / i).ToString());
                int ext = (((decimal)totalCards / i) % 1) > 0 ? 1 : 0;

                rnd = initial + ext;
                switch (rem)
                {
                    case 0:
                    case 2:
                    case 3:
                        return new { Rounds = rnd, DivisibleBy = i };
                    case 1:
                        continue; // if invalid, continue until the end
                }
            }

            if (!isValid) // All divisibility is invalid
            {
                int initial = int.Parse(Math.Truncate((decimal)totalCards / 4).ToString());
                int ext = (((decimal)totalCards / 4) % 1) > 0 ? 1 : 0;

                rnd = initial + ext;
            }

            return new { Rounds = rnd, DivisibleBy = 4 };
        }

        private IList<LocalGameTok> InitializeTokBlitzData()
        {
            var content = _hostingEnvironment.ContentRootPath;
            string jsonData = System.IO.File.ReadAllText(Path.Combine(content + "/wwwroot/js/quotesandsayings.json"));
            return JsonConvert.DeserializeObject<IList<LocalGameTok>>(jsonData);
        }

        [Route("tokblitz")]
        [HttpGet]
        public async Task<IActionResult> TokBlitz(string setId)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetTokBlitzData(string tokGroup)
        {
            var list = InitializeTokBlitzData();
            var filteredList = list.Where(x => x.tok_group == tokGroup);
            return Json(filteredList);
        }

        [HttpGet]
        public string GenerateImage(int width, int height)
        {
            List<string> Colors = new List<string>() {
            "#C0392B", "#E74C3C", "#9B59B6", "#8E44AD",
            "#2980B9", "#3498DB", "#3498DB", "#1ABC9C",
            "#16A085", "#27AE60", "#2ECC71", "#F1C40F",
            "#F39C12", "#E67E22", "#D35400", "#5DADE2" };

            var rndomColor = new Random().Next(0, Colors.Count - 1);
            Bitmap bmp = new Bitmap(width > 0 ? width : 400, height > 0 ? height : 300, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                using (SolidBrush brush = new SolidBrush(ColorTranslator.FromHtml(Colors[rndomColor])))
                {
                    graphics.FillRectangle(brush, new Rectangle(0, 0, width, height));
                }
            }

            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                return "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMyStickers(string userId, string selected)
        {
            ViewBag.SelectedStickerId = selected;
            return PartialView("Tok/_AllUserStickerViews", await _stickerService.GetStickersUserAsync(userId));
        }

        [HttpGet]
        public async Task<IActionResult> GetStickersForSale()
        {
            return PartialView("Tok/_AllStickerShopContainer", await _stickerService.GetStickersAsync());
        }

        [HttpPut]
        public async Task<IActionResult> AddStickerToTok(string stickerId, string tokId)
        {
            return Json(await _stickerService.AddStickerToTokAsync(tokId, stickerId));
        }
    }
}