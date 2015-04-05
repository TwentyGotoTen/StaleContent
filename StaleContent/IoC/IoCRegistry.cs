using Sitecore.Services.Core;
using StaleContent.DataAccess;
using StaleContent.Mappers;
using StaleContent.Repositories;
using StructureMap.Configuration.DSL;

namespace StaleContent.IoC
{
    public class IoCRegistry : Registry
    {
        public IoCRegistry()
        {
            For(typeof(IRepository<>)).Use(typeof(StaleContentRepository));
            For<Interfaces.IContentSearcher>().Use<ContentSearcher>();
            For<Interfaces.IObjectMappers>().Use<ObjectMappers>();
        }
    }
}