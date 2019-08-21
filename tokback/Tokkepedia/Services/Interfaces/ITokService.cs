using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokkepedia.Models;

namespace Tokkepedia.Services.Interfaces
{
    public interface ITokService
    {
        Task<bool> CreateTokAsync(Tok tok);
        Task<Tok> GetTokAsync(string id);
        Task<bool> UpdateTokAsync(Tok tok);
        Task<bool> DeleteTokAsync(string id);
        Task<ResultData<Tok>> GetToksAsync(TokQueryValues values = null);
        Task<ResultData<Tok>> GetToksByIdsAsync(string[] ids);
        Task<ResultData<Tok>> GetFeaturedToksAsync();
        Task<ResultData<Tok>> GetAllFeaturedToksAsync();
        Task<ResultData<Tok>> GetUserFeedAsync(int limit, string idLt = null);
        Task<ResultData<Tok>> GetToksByIdAsync(List<string> ids);
        Task<List<TokTypeList>> GetTokGroupsAsync();
        Task<List<TokTypeListCounter>> GetTokGroupCountersAsync();
        Task<TokTypeListCounter> GetTokGroupCounterAsync(string id);
        Task<List<TokTypeListUserCounter>> GetTokGroupUserCountersAsync(string userId);
        Task<Category> GetCategoryAsync(string id);
        Task<bool> CreateReportAsync(Report item);
        Task<ResultData<Category>> GetTopCategoriesWeekAsync();
        Task<ResultData<Category>> GetTopCategoriesMonthAsync();
        Task<ResultData<TokType>> GetTopTokTypesWeekAsync();
        Task<ResultData<TokType>> GetTopTokTypesMonthAsync();
        Task<ResultData<TokketUser>> GetTopUsersWeekAsync();
        Task<TokkepediaCounter> GetTokkepediaCounterAsync();
    }
}
