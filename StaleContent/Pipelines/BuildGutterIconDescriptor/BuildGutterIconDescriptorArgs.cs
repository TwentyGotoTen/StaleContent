using Sitecore.Data.Items;
using Sitecore.Pipelines;
using Sitecore.Shell.Applications.ContentEditor.Gutters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.BuildGutterIconDescriptor
{
    public class BuildGutterIconDescriptorArgs: PipelineArgs
    {
        public GutterIconDescriptor Descriptor { get; set; }
        public Item Item { get; set; } 
    }
}