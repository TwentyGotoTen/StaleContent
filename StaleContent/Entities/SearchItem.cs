using System;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
namespace StaleContent.Entities
{
    public class SearchItem : SearchResultItem
    {
        [IndexField("__refreshed")]
        public DateTime Refreshed { get; set; }

        [IndexField("__freshness_expiry")]
        public DateTime FreshnessExpiry { get; set; }

    }
}