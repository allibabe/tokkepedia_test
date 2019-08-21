using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tokkepedia.Models;
using Tokkepedia.Services;
using Tokkepedia.Services.Interfaces;
using Tokkepedia.Tools.Extensions;

namespace Tokkepedia.Controllers
{
    public class ReactionController : Controller
    {
        const string SessionTokGroupsKey = "TokGroups";
        private readonly UserManager<TokketUser> _userManager;
        private readonly IUserService _userService;
        private readonly ITokService _tokService;
        private readonly IReactionService _reactionService;

        public ReactionController(UserManager<TokketUser> userManager,
             IUserService userService,
             ITokService tokService,
             IReactionService reactionService)
        {
            _userManager = userManager;
            _userService = userService;
            _tokService = tokService;
            _reactionService = reactionService;
        }


        [HttpGet]
        public async Task<IActionResult> InitializeComments(string filter)
        {
            var res = await _reactionService.GetReactionsAsync(new ReactionQueryValues() { item_id = filter, activity_id = filter, kind = "comment" });
            var user = await _userManager.GetUserAsync(User);
            ViewBag.UserPhoto = User.Identity.IsAuthenticated ? user?.UserPhoto ?? string.Empty : string.Empty;
            if(res != null)
            {
                foreach (var comment in res.Results)
                {
                    if (comment.ChildrenCounts.Count > 0)
                    {
                        var children = await _reactionService.GetReactionsAsync(new ReactionQueryValues() { reaction_id = comment.Id, kind = "comment" });
                        comment.ChildComments = children?.Results ?? new List<TokkepediaReaction>();
                    }
                }
            }
            return PartialView("Reaction/_TokComments", res);
        }

        [HttpGet]
        public async Task<IActionResult> LoadComments(string activityId, string token)
        {
            var result = await _reactionService.GetReactionsAsync(new ReactionQueryValues() { item_id = activityId, activity_id = activityId, kind = "comment", pagination_id = token });
            var user = await _userManager.GetUserAsync(User);
            ViewBag.UserPhoto = User.Identity.IsAuthenticated ? (user?.IsAvatarProfilePicture ?? false ? user.SelectedAvatar : user?.UserPhoto) ?? string.Empty : string.Empty;
            if (result != null)
            {
                foreach (var comment in result.Results)
                {
                    if (comment.ChildrenCounts.Count > 0)
                    {
                        var children = await _reactionService.GetReactionsAsync(new ReactionQueryValues() { reaction_id = comment.Id, kind = "comment" });
                        comment.ChildComments = children?.Results ?? new List<TokkepediaReaction>();
                    }
                }
            }

            return Json(new {
                token = result?.Token ?? string.Empty,
                comments = result != null ? await this.RenderViewAsync("Reaction/_AllCommentViews", result, true) : string.Empty
            });
        }

        [HttpPost]
        public async Task<IActionResult> React([FromBody] TokkepediaReaction reaction)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                reaction.UserId = User.GetUserId();
                reaction.DetailNum = 0;

                if(reaction.Kind == "comment")
                {
                    reaction.Text = reaction.Text.TrimEnd('\r', '\n');
                    var tokmojis = PurchasesTool.GetProducts().Where(x => x.ProductType == ProductType.Tokmoji).ToList();
                    foreach (var item in tokmojis)
                    {
                        reaction.Text = reaction.Text.Replace(":"+item.Image+":", ":"+item.Id+":");
                    }
                }

                if (!string.IsNullOrEmpty(reaction.ItemId) && !reaction.IsActive)
                    result = await _reactionService.AddReaction(reaction);
                else
                    result = await _reactionService.DeleteReaction(reaction.ItemId);
            }
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleImage([FromBody] ToggleModel model)
        {
            var tokmojis = PurchasesTool.GetProducts().Where(x => x.ProductType == ProductType.Tokmoji).ToList();
            model.Text = model.Text.TrimEnd('\r', '\n');
            foreach (var item in tokmojis)
            {
                if (model.ShowImage)
                {
                    model.Text = model.Text.Replace(":" + item.Id+ ":", "<img src='" + item.Image + "' style='height: 32px;' data-toggle='tooltip' data-title='" + item.Id + "'/>");
                }
                else
                {
                    model.Text = model.Text.Replace(":" + item.Image + ":", ":" + item.Id + ":");
                }
            }
            return Json(model.Text);
        }

        #region Reactions
        //[HttpPost]
        //[ActionName("Like")]
        //public async Task<JsonResult> Like([FromBody] ReactionBodyDataBind id)
        //{
        //    //var user = await _userManager.GetUserAsync(User);
        //    apiClient = new TokkepediaApiClient();
        //    apiClient.User = new TokketUser() { Id = User.GetUserId(), IdToken = User.GetToken(), RefreshToken = User.GetStreamToken() };
        //    TokkepediaReaction item = new TokkepediaReaction()
        //    {
        //        Kind = "like",
        //        ItemId = id.activityId,
        //        UserId = id.user_id,
        //        OwnerId = id.item_user_id,
        //        DetailNum = 0
        //    };

        //    bool result;
        //    if (!string.IsNullOrEmpty(item.ItemId))
        //        result = await apiClient.AddReaction(item);
        //    else
        //        result = await apiClient.DeleteReaction(item.Id);
        //    return Json(result);
        //}

        //[HttpPost]
        //[ActionName("Dislike")]
        //public async Task<JsonResult> Dislike([FromBody] ReactionBodyDataBind id)
        //{
        //    //var user = await _userManager.GetUserAsync(User);
        //    apiClient = new TokkepediaApiClient();
        //    apiClient.User = new TokketUser() { Id = User.GetUserId(), IdToken = User.GetToken() };
        //    TokkepediaReaction item = new TokkepediaReaction()
        //    {
        //        Kind = "dislike",
        //        ItemId = id.activityId,
        //        UserId = id.user_id,
        //        OwnerId = id.item_user_id,
        //        DetailNum = 0
        //    };

        //    bool result;
        //    if (string.IsNullOrEmpty(item.Id))
        //        result = await apiClient.AddReaction(item);
        //    else
        //        result = await apiClient.DeleteReaction(item.Id);
        //    return Json(result);
        //}

        //[HttpPost]
        //[ActionName("Accurate")]
        //public async Task<JsonResult> Accurate([FromBody] ReactionBodyDataBind id)
        //{
        //    //var user = await _userManager.GetUserAsync(User);
        //    apiClient = new TokkepediaApiClient();
        //    apiClient.User = new TokketUser() { Id = User.GetUserId(), IdToken = User.GetToken() };
        //    TokkepediaReaction item = new TokkepediaReaction()
        //    {
        //        Kind = "accurate",
        //        ItemId = id.activityId,
        //        UserId = id.user_id,
        //        OwnerId = id.item_user_id,
        //        DetailNum = 0,
        //        Text = id.comment//,
        //        //CommentId = id.comment_id
        //    };

        //    bool result;
        //    if (string.IsNullOrEmpty(item.Id))
        //        result = await apiClient.AddReaction(item);
        //    else
        //        result = await apiClient.DeleteReaction(item.Id);
        //    return Json(result);
        //}

        //[HttpPost]
        //[ActionName("Inaccurate")]
        //public async Task<JsonResult> Inaccurate([FromBody] ReactionBodyDataBind id)
        //{
        //    //var user = await _userManager.GetUserAsync(User);
        //    apiClient = new TokkepediaApiClient();
        //    apiClient.User = new TokketUser() { Id = User.GetUserId(), IdToken = User.GetToken() };
        //    TokkepediaReaction item = new TokkepediaReaction()
        //    {
        //        Kind = "inaccurate",
        //        ItemId = id.activityId,
        //        UserId = id.user_id,
        //        OwnerId = id.item_user_id,
        //        DetailNum = 0,
        //        Text = id.comment//,
        //        //CommentId = id.comment_id
        //    };

        //    bool result;
        //    if (string.IsNullOrEmpty(item.Id))
        //        result = await apiClient.AddReaction(item);
        //    else
        //        result = await apiClient.DeleteReaction(item.Id);
        //    return Json(result);
        //}

        //[HttpPost]
        //[ActionName("Comment")]
        //public async Task<JsonResult> Comment([FromBody] ReactionBodyDataBind id)
        //{
        //    //var user = await _userManager.GetUserAsync(User);
        //    apiClient = new TokkepediaApiClient();
        //    apiClient.User = new TokketUser() { Id = User.GetUserId(), IdToken = User.GetToken() };
        //    TokkepediaReaction item = new TokkepediaReaction()
        //    {
        //        Kind = "inaccurate",
        //        ItemId = id.activityId,
        //        UserId = id.user_id,
        //        OwnerId = id.item_user_id,
        //        DetailNum = 0,
        //        Text = id.comment//,
        //        //CommentId = id.comment_id
        //    };

        //    bool result;
        //    if (string.IsNullOrEmpty(item.Id))
        //        result = await apiClient.AddReaction(item);
        //    else
        //        result = await apiClient.DeleteReaction(item.Id);
        //    return Json(result);
        //}

        //[HttpPost]
        //[ActionName("AccurateDetail")]
        //public async Task<JsonResult> AccurateDetail([FromBody] ReactionBodyDataBind id)
        //{
        //    //var user = await _userManager.GetUserAsync(User);
        //    apiClient = new TokkepediaApiClient();
        //    apiClient.User = new TokketUser() { Id = User.GetUserId(), IdToken = User.GetToken() };

        //    TokkepediaReaction item = new TokkepediaReaction()
        //    {
        //        Kind = "accurate",
        //        ItemId = id.activityId,
        //        UserId = id.user_id,
        //        OwnerId = id.item_user_id,
        //        DetailNum = id.detail_num,
        //        Text = id.comment
        //    };

        //    bool result;
        //    if (string.IsNullOrEmpty(item.Id))
        //        result = await apiClient.AddReaction(item);
        //    else
        //        result = await apiClient.DeleteReaction(item.Id);
        //    return Json(result);
        //}

        //[HttpPost]
        //[ActionName("InaccurateDetail")]
        //public async Task<JsonResult> InaccurateDetail([FromBody] ReactionBodyDataBind id)
        //{
        //    //var user = await _userManager.GetUserAsync(User);
        //    apiClient = new TokkepediaApiClient();
        //    apiClient.User = new TokketUser() { Id = User.GetUserId(), IdToken = User.GetToken() };
        //    TokkepediaReaction item = new TokkepediaReaction()
        //    {
        //        Kind = "inaccurate",
        //        ItemId = id.activityId,
        //        UserId = id.user_id,
        //        OwnerId = id.item_user_id,
        //        DetailNum = id.detail_num,
        //        Text = id.comment
        //    };

        //    bool result;
        //    if (string.IsNullOrEmpty(item.Id))
        //        result = await apiClient.AddReaction(item);
        //    else
        //        result = await apiClient.DeleteReaction(item.Id);
        //    return Json(result);
        //}

        //[HttpPost]
        //[ActionName("CommentDetail")]
        //public async Task<JsonResult> CommentDetail([FromBody] ReactionBodyDataBind id)
        //{
        //    //var user = await _userManager.GetUserAsync(User);
        //    apiClient = new TokkepediaApiClient();
        //    apiClient.User = new TokketUser() { Id = User.GetUserId(), IdToken = User.GetToken() };
        //    TokkepediaReaction item = new TokkepediaReaction()
        //    {
        //        Kind = "comment",
        //        ItemId = id.activityId,
        //        UserId = id.user_id,
        //        OwnerId = id.item_user_id,
        //        DetailNum = id.detail_num,
        //        Text = id.comment
        //    };

        //    bool result;
        //    if (string.IsNullOrEmpty(item.Id))
        //        result = await apiClient.AddReaction(item);
        //    else
        //        result = await apiClient.DeleteReaction(item.Id);
        //    return Json(result);
        //}

        [HttpPost]
        public async Task<ActionResult> Follow([FromBody] TokkepediaFollow token)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                //Either create new or update
                if (!String.IsNullOrEmpty(token.FollowId))
                {
                    try
                    {
                        TokkepediaFollow follow = new TokkepediaFollow()
                        {
                            IsFollowing = true,
                            UserId = user.Id,
                            UserDisplayName = user.DisplayName,
                            UserPhoto = user.UserPhoto,
                            FollowId = token.FollowId,
                            FollowDisplayName = token.FollowDisplayName,
                            FollowPhoto = token.FollowPhoto,
                            FeedLabel = "user"
                        };
                        await _userService.CreateFollowAsync(follow);
                    }
                    catch (Exception ex)
                    {
                        var m = ex.Message;
                        return Json(null);
                    }
                }
                else
                {
                    //Update
                    try
                    {
                        TokkepediaFollow follow = JsonConvert.DeserializeObject<TokkepediaFollow>(token.UserFollowed);
                        if (follow.IsFollowing)
                        {
                            follow.IsFollowing = false;
                        }
                        else { follow.IsFollowing = true; }

                        follow.FollowDisplayName = token.FollowDisplayName;
                        follow.FollowPhoto = token.FollowPhoto;
                        ++follow.UpdateCount;

                        await _userService.UpdateFollowAsync(follow);
                    }
                    catch
                    {
                        return Json(null);
                    }
                }
            }

            return Json("");
        }
        #endregion
    }
}