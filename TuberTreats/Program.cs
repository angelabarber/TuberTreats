using TuberTreats.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

List<TuberDriver> drivers = new List<TuberDriver>()
{
    new TuberDriver()
    {
        Id = 1,
        Name = "Taylor",
        TuberDeliveries = 2

    },
      new TuberDriver()
    {
        Id = 1,
        Name = "Alan",
        TuberDeliveries = 3

    },
      new TuberDriver()
    {
        Id = 1,
        Name = "Gina",
        TuberDeliveries = 1

    },
};

List <Customer> customers = new List<Customer>()
{
    new Customer()
    {
        Id = 1,
        Name = "Bonnie",
        Address = "35 peaceful drive",
        TuberOrders = 3
    },
     new Customer()
    {
        Id = 2,
        Name = "Jill",
        Address = "123 New Street",
        TuberOrders = 1
    },
     new Customer()
    {
        Id = 3,
        Name = "Britney",
        Address = "35 peaceful drive",
        TuberOrders = 2
    },
     new Customer()
    {
        Id = 4,
        Name = "Bonnie",
        Address = "35 peaceful drive",
        TuberOrders = 4
    },
     new Customer()
    {
        Id = 5,
        Name = "Bonnie",
        Address = "35 peaceful drive",
        TuberOrders = 4
    }
};

//add endpoints here

app.Run();
//don't touch or move this!
public partial class Program { }