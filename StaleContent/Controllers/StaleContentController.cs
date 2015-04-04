using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;
using StaleContent.IoC;
using StructureMap;

namespace StaleContent.Controllers
{
    [ServicesController]
    public class StaleContentController : EntityService<Entities.StaleContentItem>
    {
        private Container _container;

        public static Container Container
        {
            get
            {
                return new Container(new IoCRegistry());
            }
        }

        public StaleContentController(IRepository<Entities.StaleContentItem> repository)
            : base(repository)
        {
        }

        public StaleContentController()
            : this(Container.GetInstance<IRepository<Entities.StaleContentItem>>())
        {
        }
    }
}