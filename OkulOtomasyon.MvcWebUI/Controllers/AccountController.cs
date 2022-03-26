using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Core.CrossCuttingConcerns.Security.Web;

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
            var byUserNameAndPassword = _usersService.GetByUserNameAndPassword(userName, password);
            if (byUserNameAndPassword != null)  
            {
                AuthenticationHelper.CreateAuthCookie(new Guid(),
                    byUserNameAndPassword.UserName,
                    byUserNameAndPassword.EMail,
                    
                    DateTime.Now.AddDays(15),  
                    _usersService.getUserRoles(byUserNameAndPassword).Select(u=>u.RoleName).ToArray() , false, byUserNameAndPassword.FirstName, byUserNameAndPassword.LastName);
                return "User is Authentication Success";
            }

            return "User is Not Authentication Failed";

        }
    }
}