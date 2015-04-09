using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using StaleContent.Entities;
<<<<<<< HEAD
using StaleContent.Interfaces;
=======
>>>>>>> TwentyGotoTen/master

namespace StaleContent.DataAccess
{
    public class ContentSearcher : IContentSearcher
    {
        public List<T> GetItemsByTemplate<T>(string indexName, string templateName, Expression<Func<T, bool>> filterExpression = null) where T : SearchResultItem
        {
            using (var context = Sitecore.ContentSearch.ContentSearchManager.GetIndex(indexName).CreateSearchContext())
            {
                var queryable = context.GetQueryable<T>();

                var query = queryable.Where(x => x.TemplateName == templateName);

                var results = filterExpression != null ? query.Where(filterExpression).ToList() : query.ToList();

                return results;
            }
        }

        public List<T> GetItems<T>(string indexName, Expression<Func<T, bool>> filterExpression = null) where T : SearchResultItem
        {
            using (var context = Sitecore.ContentSearch.ContentSearchManager.GetIndex(indexName).CreateSearchContext())
            {
                var queryable = context.GetQueryable<T>();

                var results = filterExpression != null ? queryable.Where(filterExpression).ToList() : queryable.ToList();

                return results;
            }
        }

        public Expression<Func<SearchItem, bool>> CreateExpiryPredicate()
        {
            var predicate = PredicateBuilder.True<SearchItem>();

            predicate = predicate.And(i => i.FreshnessExpiry < DateTime.Now);

            return predicate;
        }
    }
}