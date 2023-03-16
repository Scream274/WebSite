namespace WebSite
{
    public class CustomMiddleWare
    {
        private readonly RequestDelegate next;

        public CustomMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string method = context.Request.Method;

            if (method == "GET")
            {

            }
            else if (method == "POST")
            {

            }

            await next.Invoke(context);
        }
    }
}
