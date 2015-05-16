using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.GetFreshnessPeriod
{
    public class GetFreshnessPeriodArgs : PipelineArgs
    {
        public int FreshnessPeriod { get; set; } 
    }
}