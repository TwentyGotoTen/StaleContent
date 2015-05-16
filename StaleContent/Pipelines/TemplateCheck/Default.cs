using Sitecore.Data;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.TemplateCheck
{
    public class Default : TemplateCheckProcessor 
    {
        ITemplateList InclusionList { get; set; } 
        ITemplateList ExclusionList { get; set; }

        public override void Process(TemplateCheckArgs args)
        {
            Assert.ArgumentNotNull(args, "args"); 
            Assert.IsNotNull(args.ItemToCheck, "args.ItemToCheck");
            Assert.IsNotNull(InclusionList, "InclusionList");
            Assert.IsNotNull(ExclusionList, "ExcludedTemplates");
            args.TemplateIsValid = MeetsListSpecifications(args.ItemToCheck.TemplateID);
        }

        private bool MeetsListSpecifications(ID id)
        { 
            return (InclusionList.Items.Any() && InclusionList.Items.Contains(id)) || 
                   !ExclusionList.Items.Contains(id);
        }
    }
}