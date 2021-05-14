using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager //farklı cache alternatifleri kullanabiliriz.Bu interface kullanacağımız bütün alternatiflerin interface' i olacak.
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key); //cache'de var mı? kontrolü için
        void Remove(string key);
        void RemoveByPattern(string pattern);

    }
}
