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


var products = new List<Produc>();


app.MapGet("/producs", () =>
{
    return products;
});


app.MapGet("/producs/{id}", (int id) =>
{

    var producs = products.FirstOrDefault(p => p.Id == id);
    return producs;
});


app.MapPost("/producs", (Produc product) =>
{
    products.Add(product);
    return Results.Ok();
});


app.MapPut("/producs/{id}", (int id, Produc product) =>
{
    var existingProduc = products.FirstOrDefault(p => p.Id == id);
    if (existingProduc != null)
    {

        existingProduc.NombreProducto = product.NombreProducto;
        existingProduc.FechaIngreso = product.FechaIngreso;
        existingProduc.FechaCaducidad = product.FechaCaducidad;
        return Results.Ok();
    }
    else
    {
        return Results.Ok();
    }
});

app.MapDelete("/producs/{id}", (int id) =>
{
    var existingProduc = products.FirstOrDefault(p => p.Id == id);
    if (existingProduc != null)
    {
        products.Remove(existingProduc);
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.Run();

//producto
internal class Produc
{
    public int Id { get; set; }
    public string NombreProducto { get; set; }
    public string FechaIngreso { get; set; }
    public string FechaCaducidad { get; set; }
}