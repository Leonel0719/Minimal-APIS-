using LADCH202309011.Auth;

namespace LADCH202309011.Endpoints
{
    public static class AccountEndpoint
    {
        static List<object> data = new List<object>();

        public static void AddAccountEndpoints(this WebApplication app)
        {

            app.MapPost("/account/login", (string login, string password, IJwtAuthenticationService authService) =>
            {
                if (login == "admin" && password == "12345")
                {
                    var token = authService.Authenticate(login);
                    return Results.Ok(token);
                }
                else
                {
                    return Results.Unauthorized();
                }
            });

            app.MapPost("/account/logout", (HttpContext context, IJwtAuthenticationService authService) =>
            {
                var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                if (data.Contains(token))
                {
                    data.Remove(token);
                }


                return Results.Ok("Se cerro la secion");
            });
        }
    }
}
