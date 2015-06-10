using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace StaleContent.Utilities
{
    public class TemplateUtil
    {
        public static List<ID> IncludedTemplates
        {
            get
            {
                return ConfigUtil.GetTemplateIDs("includeTemplates/*");
            }
        }

        public static List<ID> ExcludedTemplates
        {
            get
            {
                return ConfigUtil.GetTemplateIDs("excludeTemplates/*");
            }
        }

        public static bool TemplateIsValid(Item item)
        {
            if (TemplateUtil.IncludedTemplates.Any())
            {
                if (!TemplateUtil.IncludedTemplates.Contains(item.TemplateID))
                {
                    return  false;
                }
            }
            else if (TemplateUtil.ExcludedTemplates.Any())
            {
                if (TemplateUtil.ExcludedTemplates.Contains(item.TemplateID))
                {
                    return false;
                }
            }
            return true;
        }
    }
}