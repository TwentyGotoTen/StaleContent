using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Constants
{
    public static class PipelineNames
    {
        public static readonly string RefreshItem = "staleContent.refreshItem";
        public static readonly string TemplateCheck = "staleContent.templateCheck";
        public static readonly string GetFreshnessPeriod = "staleContent.getFreshnessPeriod";
        public static readonly string FreshnessCheck = "staleContent.freshnesscheck";
        public static readonly string BuildGutterIconDescriptor = "staleContent.buildGutterIconDescriptor";  
    }
}