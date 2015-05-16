using Sitecore;
using Sitecore.Data.Fields;
using StaleContent.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.FreshnessCheck
{
    public class Default : FreshnessCheckProcessor 
    {
        public override void Process(FreshnessCheckArgs args)
        {
            Field field = args.Item.Fields[FieldNames.FreshnessExpiry];
            if (field == null || String.IsNullOrEmpty(field.Value) || !DateUtil.IsIsoDate(field.Value))
                return;

            DateTime freshnessExpiry = DateUtil.IsoDateToDateTime(field.Value);
            if (freshnessExpiry.Date <= DateTime.Now.Date)
            {
                args.IsStale = true; 
                args.AbortPipeline();
            }
        }
    }
}