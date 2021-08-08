#region Using Statements
using System.Runtime.Serialization;
#endregion

namespace CacheManager.WebApis.Models
{
    public enum CacheObjectCollectionType : int
    {
        [EnumMember(Value = "Data XYZ")]
        DataXyz = 0        
    }
}
