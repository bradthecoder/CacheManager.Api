#region Using Statements
using System.Collections.Generic;
#endregion

namespace CacheManager.WebApis.Models
{
    public class CacheObject
    {
        public int Id { get; set; }

        public CacheObjectType Type { get; set; }

        public Dictionary<string, object> Properties { get; set; }

        //public T GetProperty<T>(string key)
        //{
        //    object tempResult = null;
        //    Properties.TryGetValue(key, out tempResult);
        //    T toReturn = (T)tempResult;
        //    return toReturn;
        //}

        //public void SetProperty(string key, object value)
        //{
        //    if (Properties.ContainsKey(key))
        //    {
        //        Properties[key] = value;
        //    }
        //    else
        //    {
        //        Properties.Add(key, value);
        //    }
        //}
    }
}
