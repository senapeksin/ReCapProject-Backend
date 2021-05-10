using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper  //ITokenHelper:İlgili kullanıcı için kullanıcının claimlerini içerecek bir token üretecek
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
