using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.FreshnessCheck
{
    public abstract class FreshnessCheckProcessor
    {
        public abstract void Process(FreshnessCheckArgs args); 
    }
}