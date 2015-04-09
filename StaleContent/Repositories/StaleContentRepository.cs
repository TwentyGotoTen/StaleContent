<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.Linq;
using StaleContent.Interfaces;
=======
﻿using StaleContent.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
>>>>>>> TwentyGotoTen/master

namespace StaleContent.Repositories
{
    public class StaleContentRepository : Sitecore.Services.Core.IRepository<Entities.StaleContentItem>
    {
<<<<<<< HEAD
        private Interfaces.IContentSearcher _iContentSearcher;
        private Interfaces.IObjectMappers _iObjectMappers;


        public StaleContentRepository(IContentSearcher iContentSearcher, IObjectMappers iObjectMappers)
        {
            _iContentSearcher = iContentSearcher;
            _iObjectMappers = iObjectMappers;
=======
        private DataAccess.IContentSearcher _iContentSearcher;

        public StaleContentRepository(IContentSearcher iContentSearcher)
        {
            _iContentSearcher = iContentSearcher;
>>>>>>> TwentyGotoTen/master
        }


        public IQueryable<Entities.StaleContentItem> GetAll()
        {
            var expiryPredicate = _iContentSearcher.CreateExpiryPredicate();
<<<<<<< HEAD

            var searchResults = _iContentSearcher.GetItems("sitecore_master_index", expiryPredicate);

            var staleContent = _iObjectMappers.MapListToListObject<Entities.SearchItem, Entities.StaleContentItem>(searchResults);

            return staleContent.AsQueryable();

=======
            var searchResults = _iContentSearcher.GetItems(Constants.Indexes.Master, expiryPredicate);
            throw new NotImplementedException();
            //var staleContent = _iObjectMappers.MapListToListObject<Entities.SearchItem, Entities.StaleContentItem>(searchResults);
            //return staleContent.AsQueryable();
>>>>>>> TwentyGotoTen/master
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