using Sitecore;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Pipelines;
using Sitecore.Shell.Applications.ContentEditor.Gutters;
using StaleContent.Pipelines.BuildGutterIconDescriptor;
using StaleContent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Gutters
{
    public class IsStale : GutterRenderer
    {
        protected override GutterIconDescriptor GetIconDescriptor(Item item)
        {
            Assert.ArgumentNotNull((object)item, "item");

            if (!FreshnessUtil.IsStale(item))
                return null;

            var descriptor = new GutterIconDescriptor();
            var args = new BuildGutterIconDescriptorArgs() 
            { 
                Item = item,
                Descriptor = descriptor
            };

            CorePipeline.Run("staleContent.buildGutterIconDescriptor",args);
            return descriptor;
        }


    }
}