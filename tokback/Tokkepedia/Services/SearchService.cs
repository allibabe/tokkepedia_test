using Firebase.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tokkepedia.Models;
using Tokkepedia.Models.ViewModels;
using Tokkepedia.Services.Interfaces;
using Tokkepedia.Tools.Extensions;

namespace Tokkepedia.Services
{
    public class SearchService : ISearchService
    {
        public static SearchServiceClient ServiceClientSearch = new SearchServiceClient("tokketdev", new SearchCredentials("5009041AD646044A29351F3B2346A819"));
        public static ISearchIndexClient IndexClientSearch = ServiceClientSearch.Indexes.GetClient("toks-index-dev");
        private readonly ITokService _tokService;

        public SearchService(ITokService tokService)
        {
            _tokService = tokService;
        }

        public List<string> GetSearchSuggestions(string text)
        {
            if (string.IsNullOrEmpty(text)) return new List<string>();
            try
            {
                bool isFuzzyEnabled = false, isHiglightsEnabled = true;

                // Call suggest API and return results
                SuggestParameters sp = new SuggestParameters()
                {
                    UseFuzzyMatching = isFuzzyEnabled,
                    Top = 5
                };

                //if (isHiglightsEnabled)
                //{
                //    sp.HighlightPreTag = "<b>";
                //    sp.HighlightPostTag = "</b>";
                //}

                DocumentSuggestResult<Microsoft.Azure.Search.Models.Document> resp = IndexClientSearch.Documents.Suggest(text, "toksdev-suggest", sp);

                // Convert the suggest query results to a list that can be displayed in the client.
                List<string> suggestions = (resp.Results.Select(x => x.Text)).Distinct().ToList();
                return suggestions;
            }
            catch (Exception e)
            {
                return new List<string>();
            }
        }

        public async Task<ResultData<Tok>> GetSearchToks(string text)
        {
            if (string.IsNullOrEmpty(text)) return new ResultData<Tok>();
            try
            {
                var result = IndexClientSearch.Documents.Search(text);
                var items = result.Results.Select(x => x.Document).ToList();
                return await _tokService.GetToksByIdsAsync(items.Select(x => x["id"]?.ToString()).ToArray());
            }
            catch (Exception e)
            {
                return new ResultData<Tok>();
            }
        }

        public List<SearchTok> ToSearchToks(List<Microsoft.Azure.Search.Models.Document> items)
        {
            List<SearchTok> toks = new List<SearchTok>();

            for (int i = 0; i < items.Count; ++i)
            {
                var item = items[i];

                SearchTok tok = new SearchTok()
                {
                    Id = item["id"]?.ToString(),
                    PrimaryText = item["primary_text"]?.ToString(),
                    SecondaryText = item["secondary_text"]?.ToString(),
                    Details = item["details"] as string[],
                    TokGroup = item["tok_group"]?.ToString(),
                    TokType = item["tok_type"]?.ToString(),
                    Category = item["category"]?.ToString(),
                    Image = item["image"]?.ToString(),
                    IsDetailBased = Convert.ToBoolean(item["is_detail_based"]),
                    NSFW = Convert.ToBoolean(item["nsfw"]),
                    CreatedTime = ((DateTimeOffset)item["created_time"]).DateTime
                };
                toks.Add(tok);
            }

            return toks;
        }

        public List<string> GetSearchAutocomplete(string text)
        {
            if (string.IsNullOrEmpty(text)) return new List<string>();
            try
            {
                bool isFuzzyEnabled = false, isHiglightsEnabled = false;

                AutocompleteParameters ap = new AutocompleteParameters()
                {
                    AutocompleteMode = AutocompleteMode.OneTermWithContext,
                    UseFuzzyMatching = isFuzzyEnabled,
                    Top = 5
                };
                AutocompleteResult autocompleteResult = IndexClientSearch.Documents.Autocomplete(text, "toksdev-suggest", ap);

                // Convert the suggest query results to a list that can be displayed in the client.
                List<string> suggestions = (autocompleteResult.Results.Select(x => x.Text)).Distinct().ToList();
                return suggestions;
            }
            catch (Exception e)
            {
                return new List<string>();
            }
        }
    }
}
