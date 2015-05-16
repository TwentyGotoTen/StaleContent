using System;

namespace StaleContent.Entities
{
    public class StaleContentItem : Sitecore.Services.Core.Model.EntityIdentity
    {
        public string itemId { get; set; }
        public string Name { get; set; }

        public DateTime Refreshed { get; set; }
        public DateTime FreshnessExpiry { get; set; }

    }
}