using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
        // Web Apinin kullanabileceği JWT'larının oluşturulması için credentials(key) imzalama nesnesini döndürecek.
        //Credentials: bir sisteme girebilmek için elinizde olanlar (kullanıcı adı, sifre gibi)
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) 
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature); //hangi anahtar hangi algoirtma kullanılacak? 
        }
    }
}
