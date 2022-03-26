using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.Mappings.AutoMapper.Profilies
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Students, Students>();
        }
    }
}
