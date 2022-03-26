using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Entities.Concrete;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.Concrete.Managers;
using OkulOtomasyon.Business.DependencyResolver.Ninject;
using OkulOtomasyon.Core.CrossCuttingConcerns.Security.Web;
using OkulOtomasyon.DataAccess.Concrete.EntityFramework;
using OkulOtomasyon.Entities.Dtos;

namespace OkulOtomasyon.UI
{
    public partial class frmUsers : Form
    {
        public frmUsers(IAuthService authService)
        {
            _authService = authService;
            InitializeComponent();
        }

        private IAuthService _authService;
        private IUsersService _usersService = new UsersManager(new EfUserDal());
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public string Login(string userName, string password)
        {
            var byUserNameAndPassword = _usersService.GetByUserNameAndPassword(userName, password);
            if (byUserNameAndPassword != null)
            {
                AuthenticationHelper.CreateAuthCookie(new Guid(),
                    byUserNameAndPassword.UserName,
                    byUserNameAndPassword.EMail,

                    DateTime.Now.AddDays(15),
                    _usersService.getUserRoles(byUserNameAndPassword).Select(u => u.RoleName).ToArray(), false, byUserNameAndPassword.FirstName, byUserNameAndPassword.LastName);
                return "User is Authentication Success";
            }

            return "User is Not Authentication Failed";

        }
    }
}
