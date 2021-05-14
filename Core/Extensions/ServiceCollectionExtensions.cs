using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // IServiceCollection (var olan sisteme) extension yapıcaz.
        //IServiceCollection : Apimizin servis bağımlılıklarını eklediğimiz yada  araya girmesini istediğimiz servisleri eklediğimiz koleksiyon. 

        //Core katmanı da dahil olmak üzere ekleyeceğimiz bütün injectionları bir araya toplayabileceğimiz bir yapı oldu.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules) //modüllerdeki herbir modül için  modlü yükle
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
