using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;
<<<<<<< HEAD
using StaleContent.IoC;
using StructureMap;
=======
>>>>>>> TwentyGotoTen/master

namespace StaleContent.Controllers
{
    [ServicesController]
    public class StaleContentController : EntityService<Entities.StaleContentItem>
    {
<<<<<<< HEAD
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
=======
        public StaleContentController(IRepository<Entities.StaleContentItem> repository) : base(repository)
        {
        }

        //public StaleContentController() : this(Container.GetInstance<IRepository<Entities.StaleContentItem>>())
        //{
        //}
>>>>>>> TwentyGotoTen/master
    }
}