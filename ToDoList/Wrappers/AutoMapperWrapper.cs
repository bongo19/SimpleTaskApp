using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Wrappers
{
    public class AutoMapperWrapper : IAutoMapperWrapper
    {
        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public object Map(object source, object destination)
        {
            return Mapper.Map(source, destination);
        }
    }
}
