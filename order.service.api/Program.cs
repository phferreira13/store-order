using order.service.efcore.Bootstrapper;
using order.service.business.UseCases.Orders;
using order.service.domain.Interfaces.HttpClients;
using order.service.http.HttpClients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(AddOrderCommand).Assembly));

builder.Services.AddEntityFramework(builder.Configuration, new(ApplyMigrations: true,  AddRepositories: true));

builder.Services.AddHttpClient<IWarehouseHttpClient, WarehouseHttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
