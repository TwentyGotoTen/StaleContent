using Sitecore;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Pipelines;
using Sitecore.Shell.Applications.ContentEditor.Gutters;
using StaleContent.Constants;
using StaleContent.Pipelines.BuildGutterIconDescriptor;
using StaleContent.Pipelines.FreshnessCheck;
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

            var freshnessCheckArgs = new FreshnessCheckArgs() { Item = item };
            CorePipeline.Run(PipelineNames.FreshnessCheck, freshnessCheckArgs);
            if (!freshnessCheckArgs.IsStale)
                return null;

            var descriptor = new GutterIconDescriptor();
            var args = new BuildGutterIconDescriptorArgs() 
            { 
                Item = item,
                Descriptor = descriptor
            }; 

            CorePipeline.Run(PipelineNames.BuildGutterIconDescriptor,args);
            return descriptor;
        }


    }
}