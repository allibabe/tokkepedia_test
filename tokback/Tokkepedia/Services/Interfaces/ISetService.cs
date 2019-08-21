using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokkepedia.Models;

namespace Tokkepedia.Services.Interfaces
{
    public interface ISetService
    {
        Task<bool> CreateSetAsync(Set set);
        Task<Set> GetSetAsync(string id);
        Task<bool> UpdateSetAsync(Set set);
        Task<bool> DeleteSetAsync(string id);
        Task<ResultData<Set>> GetSetsAsync(SetQueryValues values = null);
        Task<ResultData<Set>> GetGameSetsAsync(SetQueryValues values = null);
        Task<bool> AddTokToSetAsync(string setId, string setUserId, string tokId);
        Task<bool> DeleteTokFromSetAsync(string setId, string setUserId, string tokId);
        Task<bool> AddToksToSetAsync(string setId, string setUserId, string[] tokIds);
        Task<bool> DeleteToksFromSetAsync(Set set, string[] tokIds);
    }
}
