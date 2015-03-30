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
            args.Descriptor.Tooltip = GetTooltip();
            args.Descriptor.Click = GetCommandString(args.Item);
        }

        private String GetTooltip()
        {
            String format = Translate.Text(SettingsUtil.IsStaleGutterTooltipDictionaryKey);
            String freshnessPeriod = SettingsUtil.FreshnessPeriod.ToString();
            return String.Format(format, freshnessPeriod);
        }

        private String GetCommandString(Item item)
        {
            String format = "stalecontent:refresh(id={0})";
            String id = item.ID.ToString();
            return String.Format(format, id);
        }
    }
}