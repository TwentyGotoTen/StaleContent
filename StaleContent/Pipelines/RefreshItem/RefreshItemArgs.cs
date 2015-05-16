using Sitecore.Data.Items;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.RefreshItem
{
    public class RefreshItemArgs : PipelineArgs
    {
        public Item Item { get; set; }
        public int FreshnessPeriod { get; set; } 
    }
}