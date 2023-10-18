 namespace LADCH202309011.Endpoints
{
    public static class BodegaEndpoint
    {
        public class Bodega
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        static List<Bodega> data = new();
        public static void AddBodegaEndpoints(this WebApplication app)
        {
            app.MapPost("/bodega", (Bodega bodega) =>
            {
                data.Add(bodega);
                return Results.Ok();
            }).AllowAnonymous();

            app.MapGet("/bodega/{id}", (int id) =>
            {
                var bodegaExiste = data.FirstOrDefault(i => i.Id == id);
                if (bodegaExiste != null)
                {
                    return Results.Ok(bodegaExiste);
                }
                else
                {
                    return Results.NotFound();
                }
            }).AllowAnonymous();

            app.MapPut("/bodega/{id}", (int id, string producto) =>
            {
                var bodegaExiste = data.FirstOrDefault(i => i.Id == id);
                if (bodegaExiste != null)
                {
                    bodegaExiste.Name = producto;
                    return Results.Ok();
                }
                else
                {
                    return Results.NotFound();
                }
            }).AllowAnonymous();
        }
    }
}
