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

var proveedor = new List<Proveedor>();


app.MapGet("/proveedor", () =>
{
return proveedor;
});


app.MapGet("/proveedor/{id}", (int id) =>
{

var provee = proveedor.FirstOrDefault(p => p.Id == id);
return proveedor;
});


app.MapPost("/proveedor", (Proveedor prove) =>
{
proveedor.Add(prove);
return Results.Ok();
});


app.MapPut("/proveedor/{id}", (int id, Proveedor prove) =>
{
var existingProve = proveedor.FirstOrDefault(p => p.Id == id);
if (existingProve != null)
{

        existingProve.Nombre = prove.Nombre;

return Results.Ok();
}
else
{
return Results.Ok();
}
});

app.MapDelete("/proveedor/{id}", (int id) =>
{
var existingProve = proveedor.FirstOrDefault(p => p.Id == id);
if (existingProve != null)
{
proveedor.Remove(existingProve);
return Results.Ok();
}
else
{
return Results.NotFound();
}
});

app.Run();


internal class Proveedor
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}