using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        /*
         CacheAspect: bir tane ctor 'u var. Default değer olarak 60 verdik. Demekki süre vermezsek bu veri 60 dk boyunca cache de duracak
        daha sonra cache'den ucacak, bellekten, otomatik olarak.
         CacheAspect'te bir Aspect olduğu için injection burada yapamayız.Bu nedenle ServiceTool kullanarak hangi Cache Manager kullandığımı
        belirtiyorum.Redis kullanırsam da yapacağım tek sey Redis klasörü olusturup , CoreModul de bunu belirtmek.(buraya dokunmuyorum)
         */
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration; //duration set edildi.
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            /*
             * Key olusturacağım için ilk olarak metodumun ismini bulmaya çalısıyorum.(invocation : metod)
             * ReflectedType: Namespace 'ini al demek.
             * ReflectedType.FullName: Namespace+ Manager 'ı al demektir. Örneğin ; Northwind.Business.IProductService
             * {invocation.Method.Name} ise  çalıştırdğım metodun ismini verir. Örneğin; Northwind.Business.IProductService.GetAll()
             * arguments : Parametre demektir.
             * invocation.Arguments.ToList() : Metodun parametrelerini listeye çevir.(varsa)
             * Eğer metodun parametre değeri varsa , o parametre değerini GetAll() 'un içerisine araya virgül koyarak ekle .Örneğin; Northwind.Business.IProductService.GetAll(1)
             * Parametre yoksa orayı Null olarak geç dedim
             * Key olusturduk . Sonra diyorum ki Bellekte böyle bir cache anahtar olup olmadığını if ile kontrol ediyorum.
             * Eğer cache de varsa;
             * invocation.ReturnValue : metodu hiç çalıştırmadan geri dön demek.Kendin manuel bir return olusturuyorsun.
             * ReturnValue değeri ise;  _cacheManager.Get(key) olsun.Çünkü cache de var.
             * Ama eğer cache değeri yoksa;
             * invocation.Proceed() : metodu çalıştır ,devam ettir. 
             * MEtod çalıştığı zaman veritabanına gidecek.Datayı getirecek. Sonrasında ise;
             * _cacheManager.Add(key, invocation.ReturnValue, _duration) kodu  ile cache 'e daha önce eklenmemiş ama artık eklenmesi gerekiyor.
             * 
             * Burada yaptığımız sey,  aslında çalıştırdığımız metodun namespace'i metod ismi ve parametrelerine göre bir key olusturmak 
             * Eğer bu key daha önce varsa direk cache den al , yoksa veritabanından al ama cache ekle diyoruz.
             

            string.Join : Biraya getir demek.Aralarına virgül koyarak. (Parametrelerin herbiri için)

             -----Reflection konusuna tekrar bak !
             */

            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
