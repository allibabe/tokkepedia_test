using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokkepedia.Models;

namespace Tokkepedia.Services.Interfaces
{
    public interface INotificationService
    {
        Task<TokkepediaNotificationSet> GetNotificationsAsync(string id, NotficationQueryValues values = null);
        Task<bool> MarkAsReadAsync(string id);
        Task<bool> RemoveNotificationsAsync(string[] ids);
    }
}
