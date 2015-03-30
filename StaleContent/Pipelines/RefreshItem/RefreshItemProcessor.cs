using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaleContent.Pipelines.RefreshItem
{
    public abstract class RefreshItemProcessor
    {
        public abstract void Process(RefreshItemArgs args);
    }
}