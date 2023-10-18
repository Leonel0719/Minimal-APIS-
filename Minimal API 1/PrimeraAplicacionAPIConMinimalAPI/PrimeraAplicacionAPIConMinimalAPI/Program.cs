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


var clients = new List<Client>();


app.MapGet("/clients", () =>
{
    return clients;
});


app.MapGet("/clients/{id}", (int id) =>
{
     var client = clients.FirstOrDefault(c => c.Id == id);
    return client;

});


app.MapPost("/clients", (Client client) =>
{
    clients.Add(client);
    return Results.Ok();
});


app.MapPut("/clients/{id}", (int id, Client client) =>
{
    var existingClient = clients.FirstOrDefault(c => c.Id == id);
    if(existingClient != null)
    {

        existingClient.Name = client.Name;
        existingClient.LastName = client.LastName;
        return Results.Ok();

    }
    else
    {
        return Results.NotFound();
    }
});


app.MapDelete("/clients/{id}", (int id) =>
{
    var existingClient = clients.FirstOrDefault(c => c.Id == id);
    if (existingClient != null)
    {

        clients.Remove(existingClient);
        return Results.Ok();

    }
    else
    {
        return Results.NotFound();
    }
});


app.Run();


internal class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
};