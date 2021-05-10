using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    //ClaimsPrincipalExtensions : Bir kişinin claimlerini ararken, .net bizi biraz uğraştırıyor.
    //Bir kişinin JWT 'dan gelen claimlerini okumak için ClaimsPrincipal(bir kişinin claimlerine ulaşmak için .nette olan class ) dediğimiz classı genişletmemiz gerekiyor.
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)  //hangi claimType 'ı bulmak istiyorsam (mesela roller) ona göre işlem yapıyoruz.
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
            //? işareti null değer gelebileceği anlamına gelir.Çünkü Claim olusmamıs olabilir . 
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
            //bana coğunlukla roller lazım olduğu için ClaimRoles metodunu olustuyorum.
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
