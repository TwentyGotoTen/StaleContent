using Sitecore.Data.Items;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.FreshnessCheck
{
    public class FreshnessCheckArgs : PipelineArgs
    {
        public Item Item { get; set; }
        public bool IsStale { get; set; } 

    }
}