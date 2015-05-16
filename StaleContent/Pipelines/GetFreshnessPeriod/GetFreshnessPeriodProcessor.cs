using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.GetFreshnessPeriod
{
    public abstract class GetFreshnessPeriodProcessor
    {
        public abstract void Process(GetFreshnessPeriodArgs args); 
    }
}