using Sitecore.Configuration;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Utilities
{
    public class SettingsUtil
    {
        public static String GutterIconPath
        {
            get
            {
                return ConfigUtil.GetSetting("StaleContent.GutterIconPath", "Business/32x32/calendar_warning.png");
            }
        }

        public static int FreshnessPeriod
        {
            get
            {
                string freshnessPeriod = ConfigUtil.GetSetting("StaleContent.FreshnessPeriod", "90");
                int parsedFreshnessPeriod;
                if(int.TryParse(freshnessPeriod, out parsedFreshnessPeriod))
                {
                    Assert.IsTrue(parsedFreshnessPeriod > 0, "StaleContent.FreshnessPeriod setting must be a positive integer");
                }           
                return parsedFreshnessPeriod;
            }
        }

        public static String RefreshConfirmationDictionaryKey
        {
            get
            {
                return ConfigUtil.GetSetting("StaleContent.RefreshConfirmationDictionaryKey", "StaleContent.RefreshConfirmation");
            }
        }

        public static String IsStaleGutterTooltipDictionaryKey
        {
            get
            {
                return ConfigUtil.GetSetting("StaleContent.IsStaleGutterTooltipDictionaryKey", "StaleContent.IsStaleGutterTooltip");
            }
        }

        public static String ContentEditorWarningTitleDictionaryKey
        {
            get
            {
                return ConfigUtil.GetSetting("StaleContent.ContentEditorWarningTitleDictionaryKey", "StaleContent.ContentEditorWarningTitle");
            }
        }

        public static String ContentEditorWarningTextDictionaryKey
        {
            get
            {
                return ConfigUtil.GetSetting("StaleContent.ContentEditorWarningTextDictionaryKey", "StaleContent.ContentEditorWarningText");
            }
        }

        public static String ContentEditorWarningRefreshOptionDictionaryKey
        {
            get
            {
                return ConfigUtil.GetSetting("StaleContent.ContentEditorWarningRefreshOptionDictionaryKey", "StaleContent.ContentEditorRefreshOption");
            }
        }
    }
}