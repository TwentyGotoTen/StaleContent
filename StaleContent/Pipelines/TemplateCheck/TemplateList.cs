using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.TemplateCheck
{
    public class TemplateList : List<ID>, ITemplateList
    {
        private List<ID> _items = new List<ID>(); 

        public void AddTemplate(string id)
        {
            if (MainUtil.IsID(id))
                _items.Add(new ID(id));
        }

        public IEnumerable<ID> Items
        {
            get { return _items; }
        }
    }
}