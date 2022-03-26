using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Core.CrossCuttingConcerns.Security.Jwt;
using OkulOtomasyon.Entities.ComplexTyps;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.Abstract
{
    public interface IUsersService
    {
        User GetByUserNameAndPassword(string UserName, string Password);
        List<UserRoleItems> getUserRoles(User users);
        void Add(User user);
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
    }
}
