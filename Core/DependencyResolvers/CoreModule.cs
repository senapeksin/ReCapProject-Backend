using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        //CoreModule : Service bağımlılıklarımızı çözeceğimiz yer.
        //Daha önce Startup'da .net ile ilgili yere koyuyorduk. Bunun yerine iş süreçleri için Business'a Autofac ile beraber tasıdık,
        //Ama bunun devrede olması gerekiyor bu noktada bir tane Service Tool vasıtasıyla yaptık.
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //hazır gelen bir injection. Arka planda hazır bir ICacheManager instance olusturuyor..
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
