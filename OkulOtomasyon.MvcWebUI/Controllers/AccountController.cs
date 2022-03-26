using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Core.CrossCuttingConcerns.Security.Web;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUsersService _usersService;

        public AccountController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: Account
        public string Login(string userName, string password)
        {
            var user = _usersService.GetByUserNameAndPassword(userName, password);
            if (user != null)  
            {
                AuthenticationHelper.CreateAuthCookie(new Guid(),
                    user.UserName,
                    user.EMail,
                    DateTime.Now.AddDays(15),  
                    _usersService.getUserRoles(user).Select(u=>u.RoleName).ToArray() , false, user.FirstName, user.LastName);
                return "User is Authentication Success";
            }

            return "User is Not Authentication Failed";

        }
    }
}