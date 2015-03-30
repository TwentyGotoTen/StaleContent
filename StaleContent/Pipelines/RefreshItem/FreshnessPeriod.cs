using Sitecore.Diagnostics;
using StaleContent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.RefreshItem
{
    public class FreshnessPeriod : RefreshItemProcessor 
    {
        public override void Process(RefreshItemArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            args.FreshnessPeriod = SettingsUtil.FreshnessPeriod;
        }
    }
}