using Sitecore.Diagnostics;
using Sitecore.Pipelines;
using StaleContent.Constants;
using StaleContent.Pipelines.GetFreshnessPeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.RefreshItem
{ 
    public class DefaultFreshnessPeriod : RefreshItemProcessor 
    {
        public override void Process(RefreshItemArgs refreshArgs)
        {
            Assert.ArgumentNotNull(refreshArgs, "refreshArgs");

            var freshnessPeriodArgs = new GetFreshnessPeriodArgs();
            CorePipeline.Run(PipelineNames.GetFreshnessPeriod, freshnessPeriodArgs);

            refreshArgs.FreshnessPeriod = freshnessPeriodArgs.FreshnessPeriod;
        }
    }
}