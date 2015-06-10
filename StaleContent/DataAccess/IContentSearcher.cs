using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sitecore.ContentSearch.SearchTypes;
using StaleContent.Entities;

namespace StaleContent.DataAccess
{
    public interface IContentSearcher
    {
        List<T> GetItemsByTemplate<T>(string indexName, string templateName, Expression<Func<T, bool>> filterExpression = null) where T : SearchResultItem;
        List<T> GetItems<T>(string indexName, Expression<Func<T, bool>> filterExpression = null) where T : SearchResultItem;
        Expression<Func<SearchItem, bool>> CreateExpiryPredicate();
    }
}