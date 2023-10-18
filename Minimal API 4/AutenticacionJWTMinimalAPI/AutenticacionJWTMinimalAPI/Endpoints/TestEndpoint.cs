namespace AutenticacionJWTMinimalAPI.Endpoints
{
    public static class TestEndpoint
    {
        static List<object> data = new List<object>();

        public static void AddTestEndpoint(this WebApplication app)
        {
            app.MapGet("/test", () =>
            {
                return data;
            }).AllowAnonymous();

            app.MapPost("/test", (string name, string lastName) =>
            {
                data.Add(new { name, lastName });
                return Results.Ok();
            }).AllowAnonymous();

            app.MapDelete("/test", () =>
            {
                data = new List<object>();
                return Results.Ok();
            }).RequireAuthorization();
        }
    }
}
