using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokkepedia.Models;

namespace Tokkepedia.Services.Interfaces
{
    public interface IReactionService
    {
        Task<bool> AddReaction(TokkepediaReaction item);
        Task<bool> UpdateReaction(string id, TokkepediaReaction item);
        Task<bool> DeleteReaction(string id);
        Task<ResultData<TokkepediaReaction>> GetReactionsAsync(ReactionQueryValues values = null);
    }
}
