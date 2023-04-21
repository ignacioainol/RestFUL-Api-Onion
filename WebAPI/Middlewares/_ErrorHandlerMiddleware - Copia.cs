namespace WebAPI.Middlewares
{
    public class _ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public _ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContent context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {

                switch (error)
                {
                    case Application.Exceptions.ApiException e:
                        break;
                    case Application.Exceptions.ValidationExceptions e:
                        break;
                }
            }
        }
    }
}

