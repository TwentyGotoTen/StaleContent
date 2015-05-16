using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.BuildGutterIconDescriptor
{
    public class Default : BuildGutterIconDescriptorProcessor
    {
        public string IconPath { get; set; }
        public string TooltipKey { get; set; }

        public override void Process(BuildGutterIconDescriptorArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.IsNotNull(args.Descriptor, "args.Descriptor");
            Assert.IsNotNullOrEmpty(IconPath, "IconPath");
            Assert.IsNotNullOrEmpty(TooltipKey, "TooltipKey");

            args.Descriptor.Icon = IconPath;
            args.Descriptor.Tooltip = GetTooltip(args);
            args.Descriptor.Click = Constants.CommandNames.Refresh;
        }

        private String GetTooltip(BuildGutterIconDescriptorArgs args)
        {
            String format = Translate.Text(TooltipKey);
            String date = DateUtil.IsoDateToDateTime(args.Item[Constants.FieldNames.Refreshed]).ToShortDateString();
            return String.Format(format, date);
        }
    }
}