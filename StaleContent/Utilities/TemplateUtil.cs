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
                return GetIDsFromConfig("staleContentTemplates/includeTemplates/*");
            }
        }

        public static List<ID> ExcludedTemplates
        {
            get
            {
                return GetIDsFromConfig("staleContentTemplates/excludeTemplates/*");
            }
        }

        public static List<ID> GetIDsFromConfig(string path)
        {
            List<ID> lst = new List<ID>();
            foreach (XmlNode node in Factory.GetConfigNodes(path))
            {
                if (!string.IsNullOrWhiteSpace(node.Value))
                {
                    ID id = null;
                    if (ID.TryParse(node.Value, out id))
                    {
                        lst.Add(id);
                    }

                }
            }
            return lst;
        }
    }
}