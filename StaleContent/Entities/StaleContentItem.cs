namespace StaleContent.Entities
{
    public class StaleContentItem : Sitecore.Services.Core.Model.EntityIdentity
    {
        public string itemId { get; set; }
        public string Name { get; set; }
    }
}