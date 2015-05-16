using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using StaleContent.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.RefreshItem
{
    public class DoRefresh : RefreshItemProcessor
    {
        public override void Process(RefreshItemArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.IsNotNull(args.Item, "args.Item"); 

            if (args.FreshnessPeriod <= 0)
                return;

            DateTime expiryDate = DateTime.Now.Date.AddDays(args.FreshnessPeriod);
            String isoExpiryDate = DateUtil.ToIsoDate(expiryDate);
            String isoNow = DateUtil.ToIsoDate(DateTime.Now.Date);

            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                using (new EditContext(args.Item, false, false))
                {
                    args.Item[FieldNames.FreshnessExpiry] = isoExpiryDate;
                    args.Item[FieldNames.Refreshed] = isoNow;
                }
            }
        }
    }
}