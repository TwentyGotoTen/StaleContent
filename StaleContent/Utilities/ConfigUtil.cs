using Sitecore.Configuration;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace StaleContent.Utilities
{
    public class ConfigUtil
    {
        const string CONFIG_NODE ="staleContent";
        const string SETTINGS_NODE = "settings";
        const string SETTING_NODE = "setting";

        public static string GetSetting(string setting, string defaultValue)
        {
            var staleConfig = Factory.GetConfigNode(string.Format("{0}/{1}/{2}[@name='{3}']",CONFIG_NODE,SETTINGS_NODE,SETTING_NODE,setting));
            if (staleConfig == null)
                return defaultValue;
            return staleConfig.Attributes["value"].Value;
        }

        public static List<ID> GetTemplateIDs(string path)
        {
            List<ID> lst = new List<ID>();
            foreach (XmlNode node in Factory.GetConfigNodes(string.Format("{0}/{1}",CONFIG_NODE,path)))
            {
                if (!string.IsNullOrWhiteSpace(node.InnerText))
                {
                    ID id = null;
                    if (ID.TryParse(node.InnerText, out id))
                    {
                        lst.Add(id);
                    }
                }
            }
            return lst;
        }
    }
}