namespace ChitChat.API.Helpers;

public class JWTMiddleware
{
    private readonly RequestDelegate _next;

    public JWTMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    //public async Task Invoke(HttpContent context, iUserSe)
}