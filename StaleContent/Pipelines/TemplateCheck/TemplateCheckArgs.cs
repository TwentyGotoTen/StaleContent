using Sitecore.Data.Items;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.TemplateCheck
{
    public class TemplateCheckArgs : PipelineArgs
    {
        public Item ItemToCheck { get; set; }
        public bool TemplateIsValid { get; set; } 
    }
}