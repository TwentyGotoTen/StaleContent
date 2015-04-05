using System.Collections.Generic;

namespace StaleContent.Interfaces
{
    public interface IObjectMappers
    {
        X MapToObject<T, X>(T sourceObject);
        List<X> MapListToListObject<T, X>(List<T> sourceObject);
    }
}