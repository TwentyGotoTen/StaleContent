using Sitecore.Services.Core;
using StaleContent.Repositories;
using StructureMap.Configuration.DSL;

namespace StaleContent.IoC
{
    public class IoCRegistry : Registry
    {
        public IoCRegistry()
        {
            For(typeof(IRepository<>)).Use(typeof(StaleContentRepository));
        }
    }
}