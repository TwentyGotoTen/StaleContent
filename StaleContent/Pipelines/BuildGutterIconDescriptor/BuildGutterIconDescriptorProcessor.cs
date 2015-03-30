using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.BuildGutterIconDescriptor
{
    public abstract class BuildGutterIconDescriptorProcessor 
    {
        public abstract void Process(BuildGutterIconDescriptorArgs args);
    }
}