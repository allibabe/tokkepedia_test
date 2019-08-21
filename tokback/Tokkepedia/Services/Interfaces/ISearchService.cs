using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokkepedia.Models;

namespace Tokkepedia.Services.Interfaces
{
    public interface ISearchService
    {
        List<string> GetSearchSuggestions(string text);
        Task<ResultData<Tok>> GetSearchToks(string text);
    }
}
