using OkulOtomasyon.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Entities.Concrete;


namespace OkulOtomasyon.DataAccess.Abstract
{
    public interface ISigninDal : IEntityRepository<Signin>

    {

    }
}
