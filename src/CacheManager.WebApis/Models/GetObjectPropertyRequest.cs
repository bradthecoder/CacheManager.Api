#region Using Statements

#endregion
namespace CacheManager.WebApis.Models
{
    public class GetObjectPropertyRequest
    {
        public int Id { get; set; }

        public CacheObjectType Type { get; set; }

        public string PropertyName { get; set; }
    }
}
