using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokkepedia.Models;

namespace Tokkepedia.Services.Interfaces
{
    public interface ICommonService
    {
        Task<ResultData<TokketUser>> SearchUsersAsync(string text);
        Task<ResultData<Category>> SearchCategoriesAsync(string text);
        Task<bool> AddRecentSearchAsync(string text);
        Task<UserSearches> GetRecentSearchesAsync();
    }
}
