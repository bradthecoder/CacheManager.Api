#region Using Statements
#endregion

namespace CacheManager.WebApis.Models
{
    public class RefreshObjectRequest
    {
        public int Id { get; set; }

        public CacheObjectType Type { get; set; }

    }
}
