namespace WebSite
{
    public class StaticHttpContextExtension
    {
        public static IApplicationBuilder UseStaticCustomHttpContext(IApplicationBuilder app)
        {
            IHttpContextAccessor httpAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();

            CustomHttpContext.Configure(httpAccessor);

            return app;
        }
    }
}
