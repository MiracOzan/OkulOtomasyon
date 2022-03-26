using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Core.DataAccess;
using OkulOtomasyon.Entities.ComplexTyps;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.DataAccess.Abstract
{
    public interface IUsersDal : IEntityRepository<Users>
    {
        
        List<UserRoleItems> GetUserRoles(Users users);
    }
}
