using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.DataAccess.Abstract;
using OkulOtomasyon.Entities.ComplexTyps;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.Concrete.Managers
{
    public class UsersManager : IUsersService
    {
        private IUsersDal _UserDal;

        public UsersManager(IUsersDal iUserDal)
        {
            _UserDal = iUserDal;
        }

        public Users GetByUserNameAndPassword(string UserName, string Password)
        {
            return _UserDal.Get(u => u.UserName == UserName & u.Password == Password);
        }

        public List<UserRoleItems> getUserRoles(Users users)
        {
            return _UserDal.GetUserRoles(users);
        }
    }
}
