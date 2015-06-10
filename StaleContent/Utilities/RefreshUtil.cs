using Sitecore;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using StaleContent.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Utilities
{
    public class RefreshUtil
    {
        public static void RefreshItem(int freshnessPeriod, Item item)
        {
            if (freshnessPeriod <= 0)
                return;

            DateTime expiryDate = DateTime.Now.Date.AddDays(freshnessPeriod);
            String isoExpiryDate = DateUtil.ToIsoDate(expiryDate);
            String isoNow = DateUtil.ToIsoDate(DateTime.Now.Date);

            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                using (new EditContext(item, false, false))
                {
                    item[StatisticsFields.FreshnessExpiry] = isoExpiryDate;
                    item[StatisticsFields.Refreshed] = isoNow;
                }
            }
        }

        public static void RefreshAllContent(int freshnessPeriod)
        {
            var applicableItems = GetApplicableContentItems();
            foreach(var item in applicableItems)
            {
                RefreshItem(freshnessPeriod, item);
            }
        }

        private static List<Item> GetApplicableContentItems()
        {
            using (var context = ContentSearchManager.GetIndex("sitecore_master_index").CreateSearchContext())
            {
                IQueryable<SearchResultItem> query = context.GetQueryable<SearchResultItem>();
                var predicate = PredicateBuilder.True<SearchResultItem>();
                if (TemplateUtil.IncludedTemplates.Any())
                {
                    predicate = TemplateUtil.IncludedTemplates.Aggregate(predicate, (current, t) => current.Or(p => p.TemplateId == t));
                }
                else if (TemplateUtil.ExcludedTemplates.Any())
                {
                    predicate = TemplateUtil.ExcludedTemplates.Aggregate(predicate, (current, t) => current.Or(p => p.TemplateId != t));
                }

                predicate = predicate.And(i => i.Path.Contains("sitecore/content") && i["_latestversion"] == "1" && i.Language == Sitecore.Context.Language.Name);

                return query.Where(predicate).Select(i => (Item)i.GetItem()).ToList();
            }
        }
    }
}