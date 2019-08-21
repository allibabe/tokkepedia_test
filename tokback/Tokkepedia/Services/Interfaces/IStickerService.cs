using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokkepedia.Models;

namespace Tokkepedia.Services.Interfaces
{
    public interface IStickerService
    {
        Task<List<Sticker>> GetStickersAsync();
        Task<List<PurchasedSticker>> GetStickersUserAsync(string userId);
        Task<bool> AddStickerToTokAsync(string tokId, string newStickerId);
        Task<bool> RemoveStickerFromAsync(string tokId, string stickerId);
        Task<bool> PurchaseStickerAsync(string stickerId);
    }
}
