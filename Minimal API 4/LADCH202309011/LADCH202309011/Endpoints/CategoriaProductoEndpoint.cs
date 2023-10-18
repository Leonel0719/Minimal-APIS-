namespace LADCH202309011.Endpoints
{
    public static class CategoriaProductoEndpoint
    {
        static List<object> data = new List<object>();
        public static void AddCategoriaProductoEndpoints(this WebApplication app)
        {
            app.MapGet("/categoria", () =>
            {
                return data;
            });

            app.MapPost("/categoria", (string categoria) =>
            {
                data.Add(new { categoria });
                return Results.Ok();
            }).RequireAuthorization();
        }
    }
}
