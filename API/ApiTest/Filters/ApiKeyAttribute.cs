using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Filters
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute()
            : base(typeof(ApiKeyAuthFilter))
        {
        }
    }
}