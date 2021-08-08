#region Using Statements
using System.Collections.Generic;
#endregion

namespace CacheManager.WebApis.Models
{
    public class CacheObjectCollection
    {
        public int Id { get; set; }

        public CacheObjectCollectionType Type { get; set; }

        public List<object> Items { get; set; }

    }
}
