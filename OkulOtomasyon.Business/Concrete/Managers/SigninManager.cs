using System;
using System.Collections.Generic;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.DataAccess.Abstract;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.Concrete.Managers
{
    public class SigninManager : ISigninService
    {
        private readonly ISigninDal _signinDal;

        public SigninManager(ISigninDal signinDal)
        {
            _signinDal = signinDal;
        }

        public List<Signin> getList()
        {
            return _signinDal.GetList();
        }

        public Signin getSignin(string Username,string Password)
        {
            return _signinDal.Get(s => s.Username == Username && s.Password == Password);
        }

        public Signin addSignin(Signin neSignin)
        {
            return _signinDal.Add(neSignin);
        }
    }
}
