﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Core.DataAccess.EntityFramework;
using OkulOtomasyon.Core.Entities.Concrete;
using OkulOtomasyon.DataAccess.Abstract;
using OkulOtomasyon.Entities.ComplexTyps;
using User = OkulOtomasyon.Entities.Concrete.User;

namespace OkulOtomasyon.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, SchoolContext> ,IUsersDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }

        public List<UserRoleItems> GetUserRoles(User users)
        {
            using (SchoolContext context = new SchoolContext())
            {
                var result = from ur in context.UserRoles
                    join r in context.Roles on ur.UserId equals users.Id
                    where ur.UserId == users.Id
                    select new UserRoleItems {RoleName = r.Name};
                return result.ToList();

            }
        }
    }
}
