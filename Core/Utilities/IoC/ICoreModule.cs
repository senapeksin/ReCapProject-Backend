using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //Core: Framework katmanımız.Tüm projelerimizde kodları içeren yapıdır.
        void Load(IServiceCollection serviceCollection); //tüm bağımlılıkları(servisleri) yüklesin 
    }
}
