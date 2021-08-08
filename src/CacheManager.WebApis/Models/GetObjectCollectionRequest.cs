#region Using Statements
#endregion

namespace CacheManager.WebApis.Models
{
    public class GetObjectCollectionRequest
    {
        public int Id { get; set; }

        public CacheObjectCollectionType Type { get; set; }

    }
}
