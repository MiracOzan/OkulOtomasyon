using System.Collections.Generic;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.Abstract
{
    public interface ISigninService
    {
        List<Signin> getList();
        Signin getSignin(string Username,string Password);
        Signin addSignin(Signin neSignin);


    }
}
