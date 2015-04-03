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
                return Settings.GetSetting("StaleContent.GutterIconPath", "Business/32x32/calendar_warning.png");
            }
        }

        public static int FreshnessPeriod
        {
            get
            {
                int freshnessPeriod = Settings.GetIntSetting("StaleContent.FreshnessPeriod", 90);
                Assert.IsTrue(freshnessPeriod > 0, "StaleContent.FreshnessPeriod setting must be a positive integer");
                return freshnessPeriod;
            }
        }

        public static String RefreshConfirmationDictionaryKey
        {
            get
            {
                return Settings.GetSetting("StaleContent.RefreshConfirmationDictionaryKey", "StaleContent.RefreshConfirmation");
            }
        }

        public static String IsStaleGutterTooltipDictionaryKey
        {
            get
            {
                return Settings.GetSetting("StaleContent.IsStaleGutterTooltipDictionaryKey", "StaleContent.IsStaleGutterTooltip");
            }
        }

        public static String ContentEditorWarningTitleDictionaryKey
        {
            get
            {
                return Settings.GetSetting("StaleContent.ContentEditorWarningTitleDictionaryKey", "StaleContent.ContentEditorWarningTitle");
            }
        }

        public static String ContentEditorWarningTextDictionaryKey
        {
            get
            {
                return Settings.GetSetting("StaleContent.ContentEditorWarningTextDictionaryKey", "StaleContent.ContentEditorWarningText");
            }
        }

        public static String ContentEditorWarningRefreshOptionDictionaryKey
        {
            get
            {
                return Settings.GetSetting("StaleContent.ContentEditorWarningRefreshOptionDictionaryKey", "StaleContent.ContentEditorRefreshOption");
            }
        }
    }
}