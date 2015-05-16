using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.TemplateCheck
{
    public interface ITemplateList
    {
        void AddTemplate(string id); 
        IEnumerable<ID> Items {get;}
    }
}