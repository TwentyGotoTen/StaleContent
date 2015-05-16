using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;

namespace StaleContent.Controllers
{
    [ServicesController]
    public class StaleContentController : EntityService<Entities.StaleContentItem>
    {

        public StaleContentController(IRepository<Entities.StaleContentItem> repository)
            : base(repository)
        {
        }

        //public StaleContentController() : this(Container.GetInstance<IRepository<Entities.StaleContentItem>>())
        //{

        //}
    }
}