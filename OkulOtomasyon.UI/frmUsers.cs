using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.Concrete.Managers;
using OkulOtomasyon.Core.CrossCuttingConcerns.Security.Web;
using OkulOtomasyon.DataAccess.Concrete.EntityFramework;

namespace OkulOtomasyon.UI
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private IUsersService _usersService = new UsersManager(new EfUserDal());
        private void button1_Click(object sender, EventArgs e)
        {
            Login(textBox1.Text, textBox2.Text);
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
