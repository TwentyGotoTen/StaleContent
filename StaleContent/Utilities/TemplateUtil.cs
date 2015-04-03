using Sitecore.Configuration;
using Sitecore.Data;
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
    }
}