using System.Collections.Generic;
using System.Linq;

namespace StaleContent.Repositories
{
    public class StaleContentRepository : Sitecore.Services.Core.IRepository<Entities.StaleContentItem>
    {
        public IQueryable<Entities.StaleContentItem> GetAll()
        {
            var items = new List<Entities.StaleContentItem>();

            items.Add(new Entities .StaleContentItem(){Id = "1", itemId = "1", Name="Hello"});
            items.Add(new Entities.StaleContentItem() { Id = "2", itemId = "2", Name = "world" });

            return items.AsQueryable();
        }

        public Entities.StaleContentItem FindById(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Entities.StaleContentItem entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(Entities.StaleContentItem entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Entities.StaleContentItem entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Entities.StaleContentItem entity)
        {
            throw new System.NotImplementedException();
        }
    }
}