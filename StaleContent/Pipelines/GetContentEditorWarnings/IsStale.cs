using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Pipelines.GetContentEditorWarnings;
using StaleContent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.GetContentEditorWarnings
{
    public class IsStale 
    {
        public void Process(GetContentEditorWarningsArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.IsNotNull(args.Item, "args.Item");
            
            if (!args.Item.Versions.IsLatestVersion() || !FreshnessUtil.IsStale(args.Item))
                return;

            GetContentEditorWarningsArgs.ContentEditorWarning warning = args.Add();
            warning.Icon = SettingsUtil.GutterIconPath;
            warning.Title = Translate.Text(SettingsUtil.ContentEditorWarningTitleDictionaryKey);

            String format = Translate.Text(SettingsUtil.ContentEditorWarningTextDictionaryKey);
            String date = DateUtil.IsoDateToDateTime(args.Item[Constants.StatisticsFields.Refreshed]).ToShortDateString();
            String message = String.Format(format, date);

            warning.Text = message;
            warning.AddOption(SettingsUtil.ContentEditorWarningRefreshOptionDictionaryKey, Constants.Commands.Refresh);
            warning.IsExclusive = false;
            warning.HideFields = false;
        }
    }
}