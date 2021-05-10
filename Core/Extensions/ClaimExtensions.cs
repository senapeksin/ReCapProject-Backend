using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {
        //(claim .net den gelir).net de varolan bir nesneye yeni metodlar ekleyebiliyoruz.Buna Extensions(genişletmek) deniliyor.
        //Bir Extensions yazabilmek için hem classın hem de metodun static olması gereklidir.
        public static void AddEmail(this ICollection<Claim> claims, string email)
        //this ICollection<T> : Bu ifadeyi bir metodda görürseniz bu şu anlama gelir;bu metod "<T> " içine eklenecek demektir.
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
