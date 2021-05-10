using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    //ClaimsPrincipalExtensions : Bir kişinin claimlerini ararken, .net bizi biraz uğraştırıyor.
    //Bir kişinin JWT 'dan gelen claimlerini okumak için ClaimsPrincipal(bir kişinin claimlerine ulaşmak için .nette olan class ) dediğimiz yapıyı genişletmemiz gerekiyor.
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
