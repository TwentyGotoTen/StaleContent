using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Pipelines;
using Sitecore.Pipelines.GetContentEditorWarnings;
using StaleContent.Constants;
using StaleContent.Pipelines.FreshnessCheck;
using StaleContent.Pipelines.TemplateCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.GetContentEditorWarnings
{
    public class IsStale 
    {
        public string TitleKey { get; set; }
        public string TextKey { get; set; } 
        public string OptionKey { get; set; }
        public string IconPath { get; set; }

        public void Process(GetContentEditorWarningsArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.IsNotNull(args.Item, "args.Item");

            Assert.ArgumentNotNullOrEmpty(TitleKey, "TitleKey");
            Assert.ArgumentNotNullOrEmpty(TextKey, "TextKey");
            Assert.ArgumentNotNullOrEmpty(OptionKey, "OptionKey");
            Assert.ArgumentNotNullOrEmpty(IconPath, "IconPath");

            if (!HasValidTemplate(args.Item) || !args.Item.Versions.IsLatestVersion() || !ItemIsStale(args.Item))
                return;

            BuildWarning(args);
        }

        private void BuildWarning(GetContentEditorWarningsArgs args)
        {
            GetContentEditorWarningsArgs.ContentEditorWarning warning = args.Add();
            warning.Icon = IconPath;
            warning.Title = Translate.Text(TitleKey);

            String format = Translate.Text(TextKey);
            String date = DateUtil.IsoDateToDateTime(args.Item[Constants.FieldNames.Refreshed]).ToShortDateString();
            String message = String.Format(format, date);

            warning.Text = message;
            warning.AddOption(OptionKey, Constants.CommandNames.Refresh);
            warning.IsExclusive = false;
            warning.HideFields = false;
        }

        private bool ItemIsStale(Item item)
        {
            var freshnessCheckArgs = new FreshnessCheckArgs() { Item = item };
            CorePipeline.Run(PipelineNames.FreshnessCheck, freshnessCheckArgs);
            return freshnessCheckArgs.IsStale;         
        }

        private bool HasValidTemplate(Item item)
        { 
            var templateCheckArgs = new TemplateCheckArgs(){ItemToCheck = item };
            CorePipeline.Run(PipelineNames.TemplateCheck, templateCheckArgs);
            return templateCheckArgs.TemplateIsValid;
        }
    }
}