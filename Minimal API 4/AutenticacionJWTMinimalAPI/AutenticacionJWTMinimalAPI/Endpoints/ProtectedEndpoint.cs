namespace AutenticacionJWTMinimalAPI.Endpoints
{
    public static class ProtectedEndpoint
    {
        static List<object> data = new List<object>();

        public static void AddProtectedEndpoint(this WebApplication app)
        {
            app.MapGet("/protected", () =>
            {
                return data;
            }).RequireAuthorization();

            app.MapPost("/protected", (string name, string lastName) =>
            {
                data.Add(new { name, lastName });
                return Results.Ok();
            }).RequireAuthorization();
        }
    }
}
