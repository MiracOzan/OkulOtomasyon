using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace OkulOtomasyon.Core.Utilities.Mappings
{
    public class AuthoMapperHelper
    {
        public static List<T> MapToSameTypeList<T>(List<T> list)
        {
            Mapper.Initialize(c => { c.CreateMap<T, T>();});
            List<T> result = Mapper.Map<List<T>, List<T>>(list);
            return result;
        }

        public static T MapToSameTypeList<T>(T Obj)
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<T, T>();
            });
            T result = Mapper.Map<T, T>(Obj);
            return result;
        }
    }
}
