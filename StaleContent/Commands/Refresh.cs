using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Diagnostics;
using Sitecore;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Pipelines;
using StaleContent.Pipelines.GetFreshnessPeriod;
using StaleContent.Pipelines.RefreshItem;
using StaleContent.Constants;

namespace StaleContent.Commands
{
    public class Refresh : Command
    {
        public override void Execute(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            if (context.Items.Length != 1)
                return;

            NameValueCollection parameters = new NameValueCollection();
            parameters["items"] = this.SerializeItems(context.Items);
            Context.ClientPage.Start((object)this, "Run", parameters);
        }

        protected virtual void Run(ClientPipelineArgs args)
        {
            Assert.ArgumentNotNull((object)args, "args");

            if (!SheerResponse.CheckModified())
                return;

            if (args.IsPostBack)
                HandlePostBack(args);
            else
                DisplayPopup(args);               
        }

        private void HandlePostBack(ClientPipelineArgs args)
        {
            if (args.Result != "yes")
                return;

            Item item = this.DeserializeItems(args.Parameters["items"])[0];
            if (item == null)
                return;

            var refreshArgs = new RefreshItemArgs();
            refreshArgs.Item = item;
            CorePipeline.Run(PipelineNames.RefreshItem, refreshArgs);
        } 

        private void DisplayPopup(ClientPipelineArgs args)
        {
            String format = Translate.Text(DictionaryKeys.RefreshConfirmation);
            int freshnessPeriod = GetFreshnessPeriod();
            String strStaleDate = DateTime.Now.AddDays(freshnessPeriod).ToShortDateString();
            String message = String.Format(format, strStaleDate);
            SheerResponse.Confirm(message);
            args.WaitForPostBack();
        }

        private int GetFreshnessPeriod()
        { 
            var freshnessPeriodArgs = new GetFreshnessPeriodArgs();
            CorePipeline.Run(PipelineNames.GetFreshnessPeriod, freshnessPeriodArgs);       
            return freshnessPeriodArgs.FreshnessPeriod;
        }
    }
}