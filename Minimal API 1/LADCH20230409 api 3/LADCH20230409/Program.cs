var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var marca = new List<Marcas>();


app.MapGet("/marca/{id}", (int id) =>
{

var marcas = marca.FirstOrDefault(m => m.Id == id);
return marcas;
});


app.MapPost("/marca", (Marcas marcas) =>
{
marca.Add(marcas);
return Results.Ok();
});


app.MapPut("/marca/{id}", (int id, Marcas marcas) =>
{
var existingMarc = marca.FirstOrDefault(m => m.Id == id);
if (existingMarc != null)
{

        existingMarc.NombreMarca = marcas.NombreMarca;
        existingMarc.Ubicacion = marcas.Ubicacion;

return Results.Ok();
}
else
{
return Results.Ok();
}
});

app.MapDelete("/marca/{id}", (int id) =>
{
var existingMarc = marca.FirstOrDefault(m => m.Id == id);
if (existingMarc != null)
{
marca.Remove(existingMarc);
return Results.Ok();
}
else
{
return Results.NotFound();
}
});

app.Run();

internal class Marcas
{
    public int Id { get; set; }
    public string NombreMarca { get; set; }
    public string Ubicacion { get; set; }
}