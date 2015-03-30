using Sitecore;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Pipelines;
using StaleContent.Constants;
using StaleContent.Pipelines.RefreshItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Utilities
{
    public class FreshnessUtil
    {
        public static void Refresh(Item item)
        {
            Refresh(item, DateTime.Now.Date);
        }

        public static void Refresh(Item item, DateTime dt)
        {
            var args = new RefreshItemArgs() { Item = item };
            CorePipeline.Run("staleContent.refreshItem", args);
        }

        public static bool IsStale(Item item)
        {
            Field field = item.Fields[StatisticsFields.FreshnessExpiry];
            if(field == null || String.IsNullOrEmpty(field.Value) || !DateUtil.IsIsoDate(field.Value))
                return false;

            DateTime freshnessExpiry = DateUtil.IsoDateToDateTime(field.Value);
            return freshnessExpiry.Date <= DateTime.Now.Date;
        }
    }
}