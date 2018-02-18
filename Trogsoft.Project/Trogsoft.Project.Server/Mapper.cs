using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trogsoft.Project.Server
{
    public static class Mapper
    {
    
        private static IMapper mapper;

        private static MapperConfiguration Config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Data.User, Project.Common.User>().ReverseMap();
        });

        static Mapper()
        {
            mapper = Config.CreateMapper();
        }

        public static T Map<T>(object source)
        {
            return mapper.Map<T>(source);
        }

        public static TDest Map<TSource, TDest>(TSource source)
        {
            return mapper.Map<TSource, TDest>(source);
        }

    }
}
