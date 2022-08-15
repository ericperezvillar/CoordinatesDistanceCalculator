using System;

namespace Application.Interfaces
{
    public interface ICacheHelper
    {
        TItem Get<TItem>(string key) where TItem : class;

        void Add(object value, string key, DateTimeOffset absExpiration);
    }
}
