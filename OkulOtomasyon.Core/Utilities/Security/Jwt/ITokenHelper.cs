using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using OkulOtomasyon.Core.Utilities.Security.Jwt;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
