using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        //bu kodlar bizim , webapi de veya autofac' de olusturduğumuz injection mantığını
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)//.net 'in IServiceCollection (servislerini) kullanarak build et 
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
