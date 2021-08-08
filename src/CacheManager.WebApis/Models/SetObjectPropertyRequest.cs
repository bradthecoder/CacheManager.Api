#region Using Statements
using System.Collections.Generic;
#endregion

namespace CacheManager.WebApis.Models
{
    public class SetObjectPropertyRequest
    {
        public int Id { get; set; }

        public CacheObjectType Type { get; set; }

        public Dictionary<string,object> Properties { get; set; }

    }
}
