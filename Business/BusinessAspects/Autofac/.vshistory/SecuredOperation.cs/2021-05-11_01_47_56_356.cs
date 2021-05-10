using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessAspects.Autofac
{
    //Aspectleri normalde Core katmanında yazıyorduk.Fakat SecuredOperation Aspectini Business katmanında yazacağız. Sebebi, Autoration Aspectleri business yazılır cünkü her projenin yetkilendirme algoritması değişebilir . 
    //SecuredOperation classı JWT için.
    public class SecuredOperation : MethodInterception  //Yetki kontrolü yapacağız.
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        //IHttpContextAccessor : istek yapıldığı zaman her bir kullanıcı  için bir tane HttpContext olusur. Herkese 1 tane thread olusur yani.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');   //rolleri virgül ile ayırarark verebiliriz demiştik.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
