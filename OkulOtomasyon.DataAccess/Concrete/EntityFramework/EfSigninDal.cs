using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Core.DataAccess.EntityFramework;
using OkulOtomasyon.DataAccess.Abstract;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.DataAccess.Concrete.EntityFramework
{
    public class EfSigninDal :EfEntityRepositoryBase<Signin,SchoolContext> ,ISigninDal
    {
       
    }
}
