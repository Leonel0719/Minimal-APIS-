using LADCH.API.Endpoints;
using LADCH.API.Models.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LADCHContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"))
);

builder.Services.AddScoped<CustomerDAL>();

var app = builder.Build();

app.AddCustomerEndpoint();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();