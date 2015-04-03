using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using StaleContent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.BuildGutterIconDescriptor
{
    public class Default : BuildGutterIconDescriptorProcessor 
    {
        public override void Process(BuildGutterIconDescriptorArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.IsNotNull(args.Descriptor, "args.Descriptor");

            args.Descriptor.Icon = SettingsUtil.GutterIconPath;
            args.Descriptor.Tooltip = GetTooltip(args);
            args.Descriptor.Click = Constants.Commands.Refresh;
        }

        private String GetTooltip(BuildGutterIconDescriptorArgs args)
        {
            String format = Translate.Text(SettingsUtil.IsStaleGutterTooltipDictionaryKey);
            String date = DateUtil.IsoDateToDateTime(args.Item[Constants.StatisticsFields.Refreshed]).ToShortDateString();
            return String.Format(format, date);
        }
    }
}