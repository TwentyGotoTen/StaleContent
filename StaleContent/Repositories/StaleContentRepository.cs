using System.Collections.Generic;
using System.Linq;
using StaleContent.Interfaces;

namespace StaleContent.Repositories
{
    public class StaleContentRepository : Sitecore.Services.Core.IRepository<Entities.StaleContentItem>
    {
        private Interfaces.IContentSearcher _iContentSearcher;
        private Interfaces.IObjectMappers _iObjectMappers;


        public StaleContentRepository(IContentSearcher iContentSearcher, IObjectMappers iObjectMappers)
        {
            _iContentSearcher = iContentSearcher;
            _iObjectMappers = iObjectMappers;
        }


        public IQueryable<Entities.StaleContentItem> GetAll()
        {
            var expiryPredicate = _iContentSearcher.CreateExpiryPredicate();

            var searchResults = _iContentSearcher.GetItems("sitecore_master_index", expiryPredicate);

            var staleContent = _iObjectMappers.MapListToListObject<Entities.SearchItem, Entities.StaleContentItem>(searchResults);

            return staleContent.AsQueryable();

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