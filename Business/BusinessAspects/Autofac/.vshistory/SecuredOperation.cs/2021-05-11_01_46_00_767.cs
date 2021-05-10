using Core.Utilities.Interceptors;
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
        //istek yapıldığı zaman her kullanıcı  için bir tane thread olusturur.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); //rolleri virgül ile ayırarark verebiliriz demiştik.
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
