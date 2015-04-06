using StaleContent.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StaleContent.Repositories
{
    public class StaleContentRepository : Sitecore.Services.Core.IRepository<Entities.StaleContentItem>
    {
        private DataAccess.IContentSearcher _iContentSearcher;

        public StaleContentRepository(IContentSearcher iContentSearcher)
        {
            _iContentSearcher = iContentSearcher;
        }


        public IQueryable<Entities.StaleContentItem> GetAll()
        {
            var expiryPredicate = _iContentSearcher.CreateExpiryPredicate();
            var searchResults = _iContentSearcher.GetItems(Constants.Indexes.Master, expiryPredicate);
            throw new NotImplementedException();
            //var staleContent = _iObjectMappers.MapListToListObject<Entities.SearchItem, Entities.StaleContentItem>(searchResults);
            //return staleContent.AsQueryable();
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