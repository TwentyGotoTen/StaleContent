using Sitecore.Pipelines;
using StaleContent.Constants;
using StaleContent.Pipelines.TemplateCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.RefreshItem
{
    public class TemplateCheck : RefreshItemProcessor
    {
        public override void Process(RefreshItemArgs args)
        {
            if (args == null || args.Item == null)
                return;

            var templateCheckArgs = new TemplateCheckArgs();
            templateCheckArgs.ItemToCheck = args.Item;
            CorePipeline.Run(PipelineNames.TemplateCheck, templateCheckArgs);

            if (!templateCheckArgs.TemplateIsValid) 
                args.AbortPipeline();
        }
    }
}
