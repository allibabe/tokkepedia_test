using Firebase.Auth;
using Newtonsoft.Json;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tokkepedia.Models;

namespace Tokkepedia.Services
{
    public class TokkepediaApiClient
    {
        //Dev/QA
        private const string baseUrl = "https://tokkepediaapidev.azurewebsites.net/api/v1";
        private const string codePrefix = "?code=";
        private const string apiKey = "PXQY2m1jxGcSfXvP1RUbapHDG4VEayAvFSRKaA12dZ2v1rMJwutcPA==";

        //Production
        //private const string baseUrl = "https://tokkepediaapi.azurewebsites.net/api/v1";
        //private const string codePrefix = "?code=";
        //private const string apiKey = "o3qbCc3hDftqajYq8hKXaIic9vlZh4bPnjhjP/F6Rlboj96IwXa7aA==";

        //Testing
        //private const string baseUrl = "http://localhost:7071/api/v1";
        //private const string codePrefix = "";
        //private const string apiKey = "";

        public HttpClient client = new HttpClient();

        public TokketUser User { get; set; }

        void InitializeApiClientUser(bool userRequired = false)
        {
            if (userRequired)
            {
                if (User == null)
                    throw new UnauthorizedAccessException();
            }

            string userid = User?.Id, token = User?.IdToken, streamtoken = User?.RefreshToken;
            if (userid == null) userid = "";
            if (token == null) token = "";
            if (streamtoken == null) streamtoken = "";

            client.DefaultRequestHeaders.Add("userid", userid);
            client.DefaultRequestHeaders.Add("token", token);
            client.DefaultRequestHeaders.Add("streamtoken", streamtoken);
        }

        #region Tok
        public async Task<bool> CreateTokAsync(Tok tok)
        {
            InitializeApiClientUser(true);
            client.BaseAddress = new Uri($"{baseUrl}/tok{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, tok);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<Tok> GetTokAsync(string id)
        {
            InitializeApiClientUser();
            client.BaseAddress = new Uri($"{baseUrl}/tok/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<Tok>();
        }

        public async Task<bool> UpdateTokAsync(Tok tok)
        {
            InitializeApiClientUser(true);
            if (User.Id != tok.UserId)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/tok/{tok.Id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, tok);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTokAsync(string id)
        {
            InitializeApiClientUser(true);
            client.BaseAddress = new Uri($"{baseUrl}/tok/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<ResultData<Tok>> GetToksAsync(TokQueryValues values = null)
        {
            if (values == null)
                values = new TokQueryValues();

            client.DefaultRequestHeaders.Add("order", values?.order);
            client.DefaultRequestHeaders.Add("country", values?.country);
            client.DefaultRequestHeaders.Add("category", values?.category);
            client.DefaultRequestHeaders.Add("tokgroup", values?.tokgroup);
            client.DefaultRequestHeaders.Add("toktype", values?.toktype);
            client.DefaultRequestHeaders.Add("userid", values?.userid);
            client.DefaultRequestHeaders.Add("text", values?.text);
            client.DefaultRequestHeaders.Add("loadmore", values?.loadmore);
            client.DefaultRequestHeaders.Add("token", values?.token);
            client.DefaultRequestHeaders.Add("streamtoken", values?.streamtoken);
            client.BaseAddress = new Uri($"{baseUrl}/toks{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();

            try
            {
                var data = await response.Content.ReadAsAsync<ResultData<Tok>>();

                for (int i = 0; i < data.Results.Count; ++i)
                {
                    if (data.Results[i].UserId == "tokket")
                    {
                        data.Results[i].UserPhoto = "/images/tokket.png";
                    }
                }

                return data;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ResultData<Tok>> GetToksByIdsAsync(string[] ids)
        {
            if (ids == null)
                return null;

            if (ids.Length > 100)
                return null;

            client.BaseAddress = new Uri($"{baseUrl}/toks{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, ids);
            client = new HttpClient();

            try
            {
                var data = await response.Content.ReadAsAsync<ResultData<Tok>>();

                for (int i = 0; i < data.Results.Count; ++i)
                {
                    if (data.Results[i].UserId == "tokket")
                    {
                        data.Results[i].UserPhoto = "/images/tokket.png";
                    }
                }

                return data;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ResultData<Tok>> GetFeaturedToksAsync()
        {
            client.BaseAddress = new Uri($"{baseUrl}/featuredtoks{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();

            try
            {
                var data = await response.Content.ReadAsAsync<ResultData<Tok>>();

                for (int i = 0; i < data.Results.Count; ++i)
                {
                    if (data.Results[i].UserId == "tokket")
                    {
                        data.Results[i].UserPhoto = "/images/tokket.png";
                    }
                }

                return data;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ResultData<Tok>> GetAllFeaturedToksAsync()
        {
            client.BaseAddress = new Uri($"{baseUrl}/allfeaturedtoks{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();

            try
            {
                var data = await response.Content.ReadAsAsync<ResultData<Tok>>();

                for (int i = 0; i < data.Results.Count; ++i)
                {
                    if (data.Results[i].UserId == "tokket")
                    {
                        data.Results[i].UserPhoto = "/images/tokket.png";
                    }
                }

                return data;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ResultData<Tok>> GetUserFeedAsync(int limit, string idLt = null)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);

            //Id of the final returned item, used for pagination
            client.DefaultRequestHeaders.Add("id_lt", idLt);

            client.BaseAddress = new Uri($"{baseUrl}/userfeed/{limit}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<ResultData<Tok>>();
        }

        public async Task<ResultData<Tok>> GetToksByIdAsync(List<string> ids)
        {
            client.BaseAddress = new Uri($"{baseUrl}/toksbyid{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, ids);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<ResultData<Tok>>();
        }

        public async Task<List<TokTypeList>> GetTokGroupsAsync()
        {
            client.BaseAddress = new Uri($"{baseUrl}/tokgroups{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<List<TokTypeList>>();
        }

        public async Task<List<TokTypeListCounter>> GetTokGroupCountersAsync()
        {
            client.BaseAddress = new Uri($"{baseUrl}/tokgroupcounters{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<List<TokTypeListCounter>>();
        }

        public async Task<TokTypeList> GetTokGroupAsync(string id)
        {
            client.BaseAddress = new Uri($"{baseUrl}/tokgroup/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<TokTypeList>();
        }

        public async Task<TokTypeListCounter> GetTokGroupCounterAsync(string id)
        {
            client.BaseAddress = new Uri($"{baseUrl}/tokgroupcounter/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<TokTypeListCounter>();
        }

        /// <summary>  
        /// Gets a user tok type counter for a single tok group
        /// </summary>
        public async Task<TokTypeListUserCounter> GetTokGroupUserCounterAsync(string id)
        {
            client.BaseAddress = new Uri($"{baseUrl}/tokgroupusercounter/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<TokTypeListUserCounter>();
        }

        /// <summary>  
        /// Gets a user's tok type counters for all tok groups
        /// </summary>
        public async Task<List<TokTypeListUserCounter>> GetTokGroupUserCountersAsync(string userId)
        {
            client.BaseAddress = new Uri($"{baseUrl}/tokgroupusercounters/{userId}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<List<TokTypeListUserCounter>>();
        }

        public async Task<Category> GetCategoryAsync(string id)
        {
            Category cat = null;
            client.BaseAddress = new Uri($"{baseUrl}/category/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.Accepted:
                case System.Net.HttpStatusCode.BadRequest:
                case System.Net.HttpStatusCode.Created:
                case System.Net.HttpStatusCode.Forbidden:
                case System.Net.HttpStatusCode.NotFound:
                case System.Net.HttpStatusCode.Unauthorized:
                    cat = new Category() { Id = id };
                    break;
                case System.Net.HttpStatusCode.OK:
                    return await response.Content.ReadAsAsync<Category>();
            }

            return cat;
        }
        #endregion

        #region User
        public async Task<bool> CreateUserAsync(TokketUser item)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/user/{item.Id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, item);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<TokketUser> GetUserAsync(string id)
        {
            client.BaseAddress = new Uri($"{baseUrl}/user/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();

            var item = await response.Content.ReadAsAsync<TokketUser>();
            return JsonConvert.DeserializeObject<TokketUser>(JsonConvert.SerializeObject(item));
        }

        public async Task<bool> UpdateUserAsync(TokketUser item)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            if (User.Id != item.Id)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/user/{item.Id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, item);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/user/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<FirebaseAuthLink> SignUpAsync(string email, string password, string displayName, string country, DateTime date, string userPhoto)
        {
            TokketUser user = new TokketUser() { Email = email, PasswordHash = password, DisplayName = displayName, Country = country, Birthday = date, UserPhoto = userPhoto };
            user.BirthDate = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month)} {date.Day}";
            user.BirthYear = date.Year;
            user.BirthMonth = date.Month;
            user.BirthDay = date.Day;

            client.BaseAddress = new Uri($"{baseUrl}/signup{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, user);
            client = new HttpClient();
            var res = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FirebaseAuthLink>(res);
        }

        public async Task<FirebaseAuthLink> LoginEmailPasswordAsync(string email, string password)
        {
            TokketUser user = new TokketUser() { Email = email, PasswordHash = password };
            client.BaseAddress = new Uri($"{baseUrl}/login{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, user);
            client = new HttpClient();
            return JsonConvert.DeserializeObject<FirebaseAuthLink>(await response.Content.ReadAsStringAsync());
        }

        public async Task<FirebaseAuthLink> LoginOAuthAsync(string providerName, string token)
        {
            client.DefaultRequestHeaders.Add("providerName", providerName);
            client.DefaultRequestHeaders.Add("token", token);
            client.BaseAddress = new Uri($"{baseUrl}/loginoauth{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            var res = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FirebaseAuthLink>(res);
        }

        public async Task<bool> SendPasswordResetAsync(string email)
        {
            client.DefaultRequestHeaders.Add("email", email);
            client.BaseAddress = new Uri($"{baseUrl}/sendpasswordreset{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, email);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        /// <summary>  
        ///  Links Facebook/Google login with an Email and Password
        /// </summary>  
        public async Task<FirebaseAuthLink> LinkAccountsAsync(string token, string email, string password)
        {
            TokketUser user = new TokketUser() { Email = email, PasswordHash = password };
            client.DefaultRequestHeaders.Add("email", email);
            client.DefaultRequestHeaders.Add("password", password);
            client.DefaultRequestHeaders.Add("token", token);
            client.BaseAddress = new Uri($"{baseUrl}/linkaccounts{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, user);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<FirebaseAuthLink>();
        }
        #endregion

        public async Task<bool> CreateReportAsync(Report item)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/report{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, item);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        #region Set
        public async Task<bool> CreateSetAsync(Set set)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/set{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, set);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<Set> GetSetAsync(string id)
        {
            client.BaseAddress = new Uri($"{baseUrl}/set/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<Set>();
        }

        public async Task<bool> UpdateSetAsync(Set set)
        {
            InitializeApiClientUser(true);
            if (User == null)
                throw new UnauthorizedAccessException();
            if (User.Id != set.UserId)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/set/{set.Id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, set);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteSetAsync(string id)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/set/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<ResultData<Set>> GetSetsAsync(SetQueryValues values = null)
        {
            if (values == null)
                values = new SetQueryValues();

            client.DefaultRequestHeaders.Add("order", values?.order);
            client.DefaultRequestHeaders.Add("offset", values.offset.ToString());
            //client.DefaultRequestHeaders.Add("category", values?.category);
            //client.DefaultRequestHeaders.Add("toktype", values?.toktype);
            client.DefaultRequestHeaders.Add("userid", values?.userid);
            client.DefaultRequestHeaders.Add("text", values?.text);
            client.DefaultRequestHeaders.Add("loadmore", values?.loadmore);
            client.DefaultRequestHeaders.Add("token", values?.token);
            client.BaseAddress = new Uri($"{baseUrl}/sets{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<ResultData<Set>>();
        }

        public async Task<ResultData<Set>> GetGameSetsAsync(SetQueryValues values = null)
        {
            if (values == null)
                values = new SetQueryValues();

            client.DefaultRequestHeaders.Add("order", values?.order);
            client.DefaultRequestHeaders.Add("offset", values.offset.ToString());
            //client.DefaultRequestHeaders.Add("category", values?.category);
            //client.DefaultRequestHeaders.Add("toktype", values?.toktype);
            client.DefaultRequestHeaders.Add("userid", values?.userid);
            client.DefaultRequestHeaders.Add("text", values?.text);
            client.DefaultRequestHeaders.Add("loadmore", values?.loadmore);
            client.DefaultRequestHeaders.Add("token", values?.token);
            client.BaseAddress = new Uri($"{baseUrl}/gamesets{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<ResultData<Set>>();
        }

        public async Task<bool> AddTokToSetAsync(string setId, string setUserId, string tokId)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            if (User.Id != setUserId)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/setaddtok/{setId}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, tokId);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTokFromSetAsync(string setId, string setUserId, string tokId)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            if (User.Id != setUserId)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/setdeletetok/{setId}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, tokId);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddToksToSetAsync(string setId, string setUserId, string[] tokIds)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            if (User.Id != setUserId)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/setaddtoks/{setId}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, tokIds);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteToksFromSetAsync(Set set, string[] tokIds)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            if (User.Id != set.UserId)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/setdeletetoks/{set.Id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, tokIds);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        #endregion

        #region Follow
        public async Task<bool> CreateFollowAsync(TokkepediaFollow item)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/follow/{item.Id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, item);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<TokkepediaFollow> GetFollowAsync(string id)
        {
            client.BaseAddress = new Uri($"{baseUrl}/follow/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<TokkepediaFollow>();
        }

        public async Task<bool> UpdateFollowAsync(TokkepediaFollow tok)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            if (User.Id != tok.Id)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/follow/{tok.Id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, tok);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }
        #endregion

        #region Reaction
        public async Task<bool> AddReaction(TokkepediaReaction item)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);

            client.BaseAddress = new Uri($"{baseUrl}/reaction{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, item);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateReaction(string id, TokkepediaReaction item)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);

            client.BaseAddress = new Uri($"{baseUrl}/reaction/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, item);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteReaction(string id)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/reaction/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<ResultData<TokkepediaReaction>> GetReactionsAsync(ReactionQueryValues values = null)
        {
            if (values == null)
                values = new ReactionQueryValues();

            client.DefaultRequestHeaders.Add("limit", values?.limit.ToString());
            client.DefaultRequestHeaders.Add("kind", values?.kind);
            client.DefaultRequestHeaders.Add("activity_id", values?.activity_id);
            client.DefaultRequestHeaders.Add("user_id", values?.user_id);
            client.DefaultRequestHeaders.Add("reaction_id", values?.reaction_id);
            client.DefaultRequestHeaders.Add("pagination_id", values?.pagination_id);
            client.BaseAddress = new Uri($"{baseUrl}/reactions{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();

            try
            {
                var data = await response.Content.ReadAsAsync<ResultData<TokkepediaReaction>>();

                for (int i = 0; i < data.Results.Count; ++i)
                {
                    if (data.Results[i].UserId == "tokket")
                    {
                        data.Results[i].UserPhoto = "/images/tokket.png";
                    }
                }

                return data;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Notification

        public async Task<TokkepediaNotificationSet> GetNotificationsAsync(string id, NotficationQueryValues values = null)
        {
            if (values == null)
                values = new NotficationQueryValues();
            InitializeApiClientUser(true);

            client.DefaultRequestHeaders.Add("userid", values?.userid);
            client.DefaultRequestHeaders.Add("token", values?.token);
            client.DefaultRequestHeaders.Add("streamtoken", values?.streamtoken);
            client.DefaultRequestHeaders.Add("pagination_id", values?.pagination_id);
            client.DefaultRequestHeaders.Add("limit", values.limit.ToString());

            client.BaseAddress = new Uri($"{baseUrl}/notifications/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();

            var data = await response.Content.ReadAsAsync<TokkepediaNotificationSet>();
            return data;
        }

        //Use the id from TokkepediaNotification
        public async Task<bool> MarkAsReadAsync(string id)
        {
            InitializeApiClientUser(true);
            client.BaseAddress = new Uri($"{baseUrl}/markasread/{id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync<string>(client.BaseAddress, id);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        //Use the ids from TokkepediaNotification
        public async Task<bool> RemoveNotificationsAsync(string[] ids)
        {
            InitializeApiClientUser(true);
            client.BaseAddress = new Uri($"{baseUrl}/notifications{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, ids);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }
        #endregion

        #region Image
        public async Task<string> UploadImageAsync(string base64)
        {
            if (User == null)
                throw new UnauthorizedAccessException();

            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);

            client.BaseAddress = new Uri($"{baseUrl}/image{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, base64);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<string>();
        }

        public async Task<string> UploadProfilePictureAsync(string base64)
        {
            if (User == null)
                throw new UnauthorizedAccessException();

            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);

            client.BaseAddress = new Uri($"{baseUrl}/profilepicture{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, base64);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<string>();
        }
        #endregion

        #region Weekly/Monthly Counts
        public async Task<ResultData<Category>> GetTopCategoriesWeekAsync()
        {
            client.BaseAddress = new Uri($"{baseUrl}/categoriesweek{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<ResultData<Category>>();
        }

        public async Task<ResultData<Category>> GetTopCategoriesMonthAsync()
        {
            client.BaseAddress = new Uri($"{baseUrl}/categoriesweek{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<ResultData<Category>>();
        }

        public async Task<ResultData<TokType>> GetTopTokTypesWeekAsync()
        {
            client.BaseAddress = new Uri($"{baseUrl}/toktypesweek{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<ResultData<TokType>>();
        }

        public async Task<ResultData<TokType>> GetTopTokTypesMonthAsync()
        {
            client.BaseAddress = new Uri($"{baseUrl}/toktypesmonth{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<ResultData<TokType>>();
        }

        public async Task<ResultData<TokketUser>> GetTopUsersWeekAsync()
        {
            client.BaseAddress = new Uri($"{baseUrl}/usersweek{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<ResultData<TokketUser>>();
        }
        #endregion

        #region Purchase
        public async Task<bool> PurchaseAsync(Order item)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/purchaseweb{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, item);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }
        #endregion

        #region Search
        public async Task<ResultData<TokketUser>> SearchUsersAsync(string text)
        {
            client.DefaultRequestHeaders.Add("text", text);
            client.BaseAddress = new Uri($"{baseUrl}/searchusers{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<ResultData<TokketUser>>();
        }

        public async Task<ResultData<Category>> SearchCategoriesAsync(string text)
        {
            client.DefaultRequestHeaders.Add("text", text);
            client.BaseAddress = new Uri($"{baseUrl}/searchcategories{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<ResultData<Category>>();
        }

        public async Task<bool> AddRecentSearchAsync(string text)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.DefaultRequestHeaders.Add("text", text);
            client.BaseAddress = new Uri($"{baseUrl}/searchesaddrecent/{User.Id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, new UserSearches());
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<UserSearches> GetRecentSearchesAsync()
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/searchesgetrecent/{User.Id}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<UserSearches>();
        }
        #endregion

        #region Accessory (Avatars, Tokmoji, Stickers)
        public async Task<bool> UseAvatarAsProfilePictureAsync(bool isAvatarProfilePicture)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/avataruseasprofilepicture{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, isAvatarProfilePicture);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UserSelectAvatarAsync(string avatarId)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/avataruserselect{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, avatarId);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UserFavoriteAvatarAsync(string avatarId)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/avataruserfavorite{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, avatarId);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        /// <summary>Gets all stickers available for purchase. Used for the Stickers Shop</summary>
        public async Task<List<Sticker>> GetStickersAsync()
        {
            client.BaseAddress = new Uri($"{baseUrl}/stickers{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<List<Sticker>>();
        }

        /// <summary>Gets all stickers purchased by a user. Used in add/change/remove sticker in a tok, and also the user sticker inventory page</summary>
        public async Task<List<PurchasedSticker>> GetStickersUserAsync(string userId)
        {
            client.BaseAddress = new Uri($"{baseUrl}/stickersuser/{userId}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<List<PurchasedSticker>>();
        }

        /// <summary>Adds a tok sticker or changes the existing one. Works as both an add and update function</summary>
        public async Task<bool> AddStickerToTokAsync(string tokId, string newStickerId)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/stickertokupdate/{tokId}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, newStickerId);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        /// <summary>Removes a tok sticker</summary>
        public async Task<bool> RemoveStickerFromAsync(string tokId, string stickerId)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.BaseAddress = new Uri($"{baseUrl}/stickertokupdate/{tokId}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PutAsJsonAsync(client.BaseAddress, stickerId);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }

        /// <summary>Purchases a sticker for a user</summary>
        public async Task<bool> PurchaseStickerAsync(string stickerId)
        {
            if (User == null)
                throw new UnauthorizedAccessException();
            client.DefaultRequestHeaders.Add("userid", User.Id);
            client.DefaultRequestHeaders.Add("token", User.IdToken);
            client.DefaultRequestHeaders.Add("deviceplatform", "web");
            client.BaseAddress = new Uri($"{baseUrl}/purchasecoins/{stickerId}{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, stickerId);
            client = new HttpClient();
            return response.IsSuccessStatusCode;
        }
        #endregion

        public async Task<TokkepediaCounter> GetTokkepediaCounterAsync()
        {
            client.BaseAddress = new Uri($"{baseUrl}/tokkepediacounter{codePrefix}{apiKey}");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            client = new HttpClient();
            return await response.Content.ReadAsAsync<TokkepediaCounter>();
        }
    }
}
