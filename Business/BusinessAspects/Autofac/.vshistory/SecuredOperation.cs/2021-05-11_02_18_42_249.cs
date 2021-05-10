using Business.Constants;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;

namespace Business.BusinessAspects.Autofac
{
    //Aspectleri normalde Core katmanında yazıyorduk.Fakat SecuredOperation Aspectini Business katmanında yazacağız. Sebebi, Autoration Aspectleri business yazılır cünkü her projenin yetkilendirme algoritması değişebilir . 
    //SecuredOperation classı JWT için.
    public class SecuredOperation : MethodInterception  //SecuredOperation :Yetki kontrolü yapacağız.
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        //IHttpContextAccessor : istek yapıldığı zaman her bir kullanıcı  için bir tane HttpContext olusur. Herkese 1 tane thread olusur yani.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');   //rolleri virgül ile ayırarark verebiliriz demiştik.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //ServiceTool,  bizim injection altyapımızı aynen okuyabilmemizi yarayan bir araç olacak.
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles(); //ilgili kullanıcının claim rollerini bul
            foreach (var role in _roles)//rollerini gez,eğer claimlerinin içinde ilgili role varsa return et
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied); //eğerki kullanıcının claimi yoksa yetkin yok hatası ver.
        }
    }
}
