#region Using Statements
#endregion

namespace CacheManager.WebApis.Models
{
    public class GetObjectRequest
    {
        public int Id { get; set; }

        public CacheObjectType Type { get; set; }

    }
}
