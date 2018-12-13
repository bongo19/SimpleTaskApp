using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ToDoList.Wrappers
{
    public interface IAutoMapperWrapper
    {
        TDestination Map<TDestination>(object source);
        object Map(object source, object destination);
    }
}
