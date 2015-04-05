using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using StaleContent.Constants;
using StaleContent.Utilities;
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

            Assert.ArgumentNotNull(args, "args");
            Assert.IsNotNull(args.Item, "args.Item");

            RefreshUtil.RefreshItem(args.FreshnessPeriod, args.Item);
        }
    }
}