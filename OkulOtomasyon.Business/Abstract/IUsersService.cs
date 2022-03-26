using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Entities.ComplexTyps;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.Abstract
{
    public interface IUsersService
    {
        Users GetByUserNameAndPassword(string UserName, string Password);
        List<UserRoleItems> getUserRoles(Users users);
    }
}
