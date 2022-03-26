using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Core.CrossCuttingConcerns.Security.Jwt;
using OkulOtomasyon.Core.DataAccess;
using OkulOtomasyon.Entities.ComplexTyps;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.DataAccess.Abstract
{
    public interface IUsersDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<UserRoleItems> GetUserRoles(User users);
    }
}
