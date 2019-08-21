using System;
using System.Collections.Generic;
using System.Linq;
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
using Tokkepedia.Tools.Helpers;

namespace Tokkepedia.Controllers
{
    public class SetController : Controller
    {
        const string SessionTokGroupsKey = "TokGroups";
        private readonly UserManager<TokketUser> _userManager;
        private readonly IUserService _userService;
        private readonly ITokService _tokService;
        private readonly IReactionService _reactionService;
        private readonly ISetService _setService;

        public SetController(UserManager<TokketUser> userManager,
             IUserService userService,
             ITokService tokService,
             IReactionService reactionService,
             ISetService setService)
        {
            _userManager = userManager;
            _userService = userService;
            _tokService = tokService;
            _reactionService = reactionService;
            _setService = setService;
        }

        [Route("set")]
        [ActionName("SetToks")]
        public async Task<IActionResult> SetToks(string id)
        {
            SetViewModel viewModel = new SetViewModel();

            if (User!= null)
            {
                var item = await _setService.GetSetAsync(id);

                if (item == null)
                {
                    viewModel.CurrentSet = new Set()
                    {
                        Name = "Set not found",
                        Description = "Please try a different set id",
                        TokIds = new List<string>()
                    };
                }
                else
                {
                    viewModel.CurrentSet = item;
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [Route("tokcards")]
        public async Task<IActionResult> PlayToks(string id, FilterType type = FilterType.None, int cnt = 0)
        {
            SetViewModel viewModel = new SetViewModel();
            ResultData<Tok> tokResult = new ResultData<Tok>();
            tokResult.Results = new List<Tok>();
            var tempToks = new List<Tok>();
            string strtoken = string.Empty, pagetoken = string.Empty;
            if (User.Identity.IsAuthenticated)
                strtoken = User.GetStreamToken();

            if (User != null)
            {
                if(User.Identity.IsAuthenticated)
                {
                    switch (type)
                    {
                        case FilterType.Category:
                            for (int i = 0; i <= cnt; i++)
                            {
                                if(string.IsNullOrEmpty(pagetoken))
                                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { category = id, streamtoken = strtoken });
                                else
                                    tokResult = await _tokService.GetToksAsync(new TokQueryValues() { category = id, loadmore = "yes", token = pagetoken, order = "newest" });

                                pagetoken = tokResult.Token;
                                tempToks.AddRange(tokResult.Results);
                            }
                            viewModel.Toks = tempToks;
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
                            viewModel.Toks = tempToks;
                            break;
                        case FilterType.None:
                        default:
                            var item = await _setService.GetSetAsync(id);

                            if (item == null)
                            {
                                viewModel.CurrentSet = new Set()
                                {
                                    Name = "Set not found",
                                    Description = "Please try a different set id",
                                    TokIds = new List<string>()
                                };

                                if (string.IsNullOrEmpty(id))
                                {
                                    tokResult = await _tokService.GetAllFeaturedToksAsync();
                                    viewModel.Toks = tokResult.Results;
                                }
                            }
                            else
                            {
                                viewModel.CurrentSet = item;
                                var list = new List<Tok>();
                                var newToken = string.Empty;
                                var tokRes = await _tokService.GetToksByIdsAsync(item.TokIds.ToArray());
                                if (tokRes != null)
                                {
                                    list = tokRes.Results;
                                    newToken = tokRes.Token;
                                }

                                viewModel.Toks = list;
                                viewModel.Token = newToken;
                            }
                            break;
                    }
                }
                else
                {
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
                                    tempToks.AddRange(tokResult.Results);
                                }
                                viewModel.Toks = tempToks;
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
                                viewModel.Toks = tempToks;
                                break;
                            case FilterType.None:
                            default:
                                tokResult = await _tokService.GetAllFeaturedToksAsync();
                                viewModel.Toks = tokResult.Results;
                                break;
                        }
                    }
                    else if (string.IsNullOrEmpty(id))
                    {
                        tokResult = await _tokService.GetAllFeaturedToksAsync();
                        viewModel.Toks = tokResult.Results;
                    }
                    else
                        return RedirectToAction("Index");
                }
            }
            else
            {
                if(!string.IsNullOrEmpty(id))
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
                                tempToks.AddRange(tokResult.Results);
                            }
                            viewModel.Toks = tempToks;
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
                            viewModel.Toks = tempToks;
                            break;
                        case FilterType.None:
                        default:
                            tokResult = await _tokService.GetAllFeaturedToksAsync();
                            viewModel.Toks = tokResult.Results;
                            break;
                    }
                }
                else if (string.IsNullOrEmpty(id))
                {
                    tokResult = await _tokService.GetAllFeaturedToksAsync();
                    viewModel.Toks = tokResult.Results;
                }
                else
                    return RedirectToAction("Index");
            }

            ViewBag.Id = id;
            ViewBag.DataType = (int)type;
            ViewBag.DataCounter = cnt;
            ViewBag.OfflineToks = tokResult.Results;

            return View("TokCards", viewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetSetToks(string setId, int takeCnt = 100, int skip = 0, bool isListing = false, bool isCard = false)
        {
            ResultData<Tok> tokResult = new ResultData<Tok>();
            tokResult.Results = new List<Tok>();
            var item = await _setService.GetSetAsync(setId);

            var list = new List<Tok>();
            var newToken = string.Empty;
            if (skip < item.TokIds.Count) // Check if there's new
            {
                var tokRes = await _tokService.GetToksByIdsAsync(item.TokIds.Skip(skip).Take(takeCnt).ToArray());
                list = tokRes.Results;
                newToken = tokRes.Token;
            }   

            tokResult.Results = list;
            tokResult.Token = newToken;

            if (!isListing) // If not true, do the default results else will override the partialview
            {
                if (skip == 0)
                {
                    if(isCard)
                        return PartialView("Tok/_TokCardContainer", tokResult);
                    else
                        return PartialView("Tok/_SetTokContainer", tokResult);
                }
                else
                {
                    if (isCard)
                        return PartialView("Tok/_AllTokCardViews", tokResult);
                    else
                        return PartialView("Tok/_AllSetTokViews", tokResult);
                }
            }
            else
                return PartialView("Tok/_ToksListingWithSelection", tokResult);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllToks(string tokTypeId, string token)
        {
            ResultData<Tok> tokResult = new ResultData<Tok>();
            tokResult.Results = new List<Tok>();
            var list = new List<Tok>();
            ViewBag.ShowCategory = true;

            if (!string.IsNullOrEmpty(tokTypeId))
            {
                var qry = new TokQueryValues() { toktype = tokTypeId };
                if (!string.IsNullOrEmpty(token))
                {
                    qry.loadmore = "yes";
                    qry.token = token;
                }

                tokResult = await _tokService.GetToksAsync(qry);
            }

            return PartialView("Tok/_ToksListingWithSelection", tokResult);
        }

        [HttpPost]
        public async Task<IActionResult> AddToksToSet(string setId, List<string> tokIds)
        {
            ResultViewModel result = new ResultViewModel() { ResultEnum = Result.Failed, ResultMessage = "Saving Failed!" };

            if(tokIds.Count > 0)
            {
                var flag = await _setService.AddToksToSetAsync(setId, User.GetUserId(), tokIds.ToArray());
                if (flag)
                {
                    result.ResultEnum = Result.Success;
                    result.ResultMessage = "Save Successful!";
                }
            }

            return Json(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveToksFromSet(string setId, List<string> tokIds)
        {
            ResultViewModel result = new ResultViewModel() { ResultEnum = Result.Failed, ResultMessage = "Saving Failed!" };

            if (tokIds.Count > 0)
            {
                var set = await _setService.GetSetAsync(setId);
                var flag = await _setService.DeleteToksFromSetAsync(set, tokIds.ToArray());
                if (flag)
                {
                    result.ResultEnum = Result.Success;
                    result.ResultMessage = "Delete Successful!";
                }
            }

            return Json(result);
        }

        [Authorize]
        [Route("mysets")]
        [ActionName("MySets")]
        public async Task<IActionResult> MySets()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> InitializeMySets(string filter = "", FilterType type = FilterType.None, bool WithSelection = false)
        {
            MySetsViewModel viewModel = new MySetsViewModel();

            if (User != null)
            {
                ResultData<Set> setResults = null;
                switch (type)
                {
                    case FilterType.None:
                        break;
                    case FilterType.TokType:
                        setResults = await _setService.GetSetsAsync(new SetQueryValues() { toktypeid = filter });
                        break;
                    case FilterType.Text:
                        break;
                    case FilterType.Category:
                        break;
                    case FilterType.Country:
                        break;
                    case FilterType.User:
                        setResults = await _setService.GetSetsAsync(new SetQueryValues() { userid = User.GetUserId() });
                        break;
                }
                viewModel.Sets = setResults?.Results ?? new List<Set>();
                viewModel.Token = setResults?.Token ?? string.Empty;
            }
            else
            {
                return RedirectToAction("Index");
            }

            PartialViewResult view;

            if (WithSelection)
                view = PartialView("Set/_SetsListingWithSelection", viewModel);
            else
                view = PartialView("Set/_SetsListing", viewModel);

            return view;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> InitializeMyGameSets(string filter = "", FilterType type = FilterType.None)
        {
            MySetsViewModel viewModel = new MySetsViewModel();

            if (User != null)
            {
                ResultData<Set> setResults = null;
                switch (type)
                {
                    case FilterType.None:
                        break;
                    case FilterType.TokType:
                        break;
                    case FilterType.Text:
                        break;
                    case FilterType.Category:
                        break;
                    case FilterType.Country:
                        break;
                    case FilterType.User:
                        setResults = await _setService.GetGameSetsAsync(new SetQueryValues() { userid = User.GetUserId() });
                        break;
                }
                if (setResults.Results != null)
                    viewModel.GameSets = setResults.Results;
                viewModel.Token = setResults.Token;
            }
            else
            {
                return RedirectToAction("Index");
            }

            return PartialView("Set/_GameSetsListing", viewModel);
        }

        [Authorize]
        [Route("addset")]
        [ActionName("AddSet")]
        public async Task<IActionResult> AddSet()
        {
            AddSetViewModel vm = new AddSetViewModel();
            if (HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey) == null)
            {
                var groups = await _tokService.GetTokGroupsAsync();
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
        [Route("addset")]
        [ActionName("AddSet")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSet([Bind("Set,TokGroupDataString, Base64Image")] AddSetViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var groups = JsonConvert.DeserializeObject<List<TokTypeList>>(viewModel.TokGroupDataString);
                var selectedGroup = groups.Find(x => x.TokGroup == viewModel.Set.TokGroup);

                var user = await _userManager.GetUserAsync(User);
                //User data
                viewModel.Set.UserDisplayName = user.UserName;
                viewModel.Set.UserId = user.Id;

                //Image Uploading will be done in the same function
                viewModel.Set.Image = viewModel.Base64Image;
                //!string.IsNullOrEmpty(viewModel.Base64Image) ? await apiClient.UploadImageAsync(viewModel.Base64Image) : "";

                viewModel.Set.TokTypeId = $"toktype-{viewModel.Set.TokGroup.ToIdFormat()}-{viewModel.Set.TokType.ToIdFormat()}";
                await _setService.CreateSetAsync(viewModel.Set);
            }

            return RedirectToAction("MySets");
        }

        [HttpPost]
        public async Task<IActionResult> AddGameSet([FromBody] AddGameSetViewModel model)
        {
            var result = new ResultViewModel();
            result.ResultEnum = Result.Failed;
            result.ResultMessage = "Please select at least 5 or 10 toks.";

            if(model.TokIds.Count == 5 || model.TokIds.Count == 10)
            {
                model.Set = await _setService.GetSetAsync(model.Set.Id); // Replace with full data

                // Call Create Game Sets
                if(await _setService.CreateSetAsync(model.Set)) // Dummy
                {
                    result.ResultEnum = Result.Success;
                }
                else 
                    result.ResultMessage = "Service Failed! Please try again later.";
            }

            return Json(result);
        }

        #region Set actions
        [HttpPost]
        [ActionName("EditSet")]
        public async Task<JsonResult> EditSet([FromBody] GroupBind id)
        {
            try
            {
                var set = JsonConvert.DeserializeObject<Set>(id.group);
                await _setService.UpdateSetAsync(set);
                return Json(""); //return null;
            }
            catch
            {
                return null;
            }
        }

        [HttpDelete]
        [ActionName("DeleteSet")]
        public async Task<JsonResult> DeleteSet([FromBody] GroupBind id)
        {
            string e = "";
            try
            {
                await _setService.DeleteSetAsync(id.group);
            }
            catch (Exception ex)
            {
                e = ex.Message;
                return null;
            }
            return Json(e); //return null;
        }
        
        [HttpDelete]
        public async Task<IActionResult> RemoveTokFromSet(string setId, string tokId)
        {
            var result = new ResultViewModel();
            result.ResultEnum = Result.Failed;
            result.ResultMessage = "Failed to Remove Tok";

            if (!string.IsNullOrEmpty(tokId) || !string.IsNullOrEmpty(setId))
            {
                if (await _setService.DeleteTokFromSetAsync(setId, User.GetUserId(), tokId))
                {
                    result.ResultEnum = Result.Success;
                    result.ResultMessage = "Remove Successful!";
                }
            }
            else
            {
                result.ResultMessage = "Something went wrong.";
            }

            return Json(result);
        }
        #endregion
    }
}