using Sitecore;
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

            if (!TemplateUtil.TemplateIsValid(item))
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
    }
}