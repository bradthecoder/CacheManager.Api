#region Using Statements
#endregion

namespace CacheManager.WebApis.Models
{
    public class ResponseBase<T> where T : class
    {
        public T Message { get; set; }

        public ErrorData Error { get; set; }

        public class ErrorData
        {
            public string Message { get; set; }
        }

    }
}
