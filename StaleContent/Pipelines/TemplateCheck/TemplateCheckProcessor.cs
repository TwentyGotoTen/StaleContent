using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.TemplateCheck
{
    public abstract class TemplateCheckProcessor
    {
        public abstract void Process(TemplateCheckArgs args); 
    }
}