using StaleContent.Utilities;
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

            if(TemplateUtil.IncludedTemplates.Any())
            {
                if(!TemplateUtil.IncludedTemplates.Contains(args.Item.TemplateID))
                {
                    args.AbortPipeline(); 
                }
            }
            else if(TemplateUtil.ExcludedTemplates.Any())
            {
                if(TemplateUtil.ExcludedTemplates.Contains(args.Item.TemplateID))
                {
                     args.AbortPipeline(); 
                }
            }               
        }
    }
}