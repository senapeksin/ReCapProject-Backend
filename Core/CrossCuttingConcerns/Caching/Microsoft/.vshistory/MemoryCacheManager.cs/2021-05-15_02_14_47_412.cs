using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter pattern : var olan bir sistemi , kendi sistemime uyarlıyorum.

        IMemoryCache _memoryCache;


        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>(); //IMemoryCache in karşılığını ver. 
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);//Sadece bellekte böyle bir anahtar var mı yok mu onu bulmak istiyorum, varsa bu değerin datasını istemiyorum bu sebeple "out _" diyorum.
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern) //içinde sadece ".." ifadesi geçenleri  sil gibi bir desen vererek silme işlemi gerçekleştirilebilir.
        {
            //RemoveByPattern bellekten silmeye yarıyor.Çalışma anında  bellekten silmeye yarıyor.Yani elinizde bir sınıfın instance var bellekte ve ona çalışma anında müdahale etmek istiyorsunuz.
            //Bunu Reflection ile yapıyoruz. Reflection ile çalısma anında , elinizde bulunan nesnelere yoksa da o an olusturabilme çalışması yapabilirsniz.
            //Koda çalışma anında  olusturma ve müdahale etme gibi seyleri Reflection ile yapıyoruz.

            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
