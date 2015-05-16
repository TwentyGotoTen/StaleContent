using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.GetFreshnessPeriod
{
    public class Default : GetFreshnessPeriodProcessor 
    {
        public int DefaultFreshnessPeriod { get; set; }

        public override void Process(GetFreshnessPeriodArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            args.FreshnessPeriod = DefaultFreshnessPeriod;
        }
    }
}