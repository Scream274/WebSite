namespace WebSite
{
    public static class CustomHttpContext
    {
        private static IHttpContextAccessor _httpContextAccessor;
        public static HttpContext HttpContext
        {
            get
            {
                return _httpContextAccessor.HttpContext;
            }
        }

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
