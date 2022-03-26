using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Core.Aspects.PostSharp.LogAspects;
using OkulOtomasyon.Core.CrossCuttingConcerns.Logging.Log4net.Loggers;
using OkulOtomasyon.Core.CrossCuttingConcerns.Security.Jwt;
using OkulOtomasyon.DataAccess.Abstract;
using OkulOtomasyon.Entities.ComplexTyps;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.Concrete.Managers
{
    public class UsersManager : IUsersService
    {
        private readonly IUsersDal _userDal;

        public UsersManager(IUsersDal UserDal)
        {
            _userDal = UserDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        public User GetByUserNameAndPassword(string UserName, string Password)
        {
            return _userDal.Get(u => u.UserName == UserName & u.Password == Password);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public List<UserRoleItems> getUserRoles(User users)
        {
            return _userDal.GetUserRoles(users);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.EMail == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }


    }
}
