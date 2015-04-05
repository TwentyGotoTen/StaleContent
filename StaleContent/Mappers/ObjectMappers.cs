using System.Collections.Generic;
using AutoMapper;
using StaleContent.Interfaces;

namespace StaleContent.Mappers
{
    public class ObjectMappers : IObjectMappers
    {
        public X MapToObject<T, X>(T sourceObject)
        {
            return Mapper.Map<T, X>(sourceObject);
        }

        public List<X> MapListToListObject<T, X>(List<T> sourceObject)
        {
            Mapper.CreateMap<T, X>();

            return Mapper.Map<List<T>, List<X>>(sourceObject);
        }
    }
}