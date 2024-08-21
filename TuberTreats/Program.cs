using TuberTreats.Models;
using TuberTreats.Models.DTOs;

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
    },
     new Customer()
    {
        Id = 2,
        Name = "Jill",
        Address = "123 New Street",
    },
     new Customer()
    {
        Id = 3,
        Name = "Britney",
        Address = "35 peaceful drive",
    },
     new Customer()
    {
        Id = 4,
        Name = "Bonnie",
        Address = "35 peaceful drive",
    },
     new Customer()
    {
        Id = 5,
        Name = "Bonnie",
        Address = "35 peaceful drive",
    }
};

List <Topping> toppings = new List<Topping>()
{
    new Topping()
    {
        Id = 1,
        Name = "Butter"
    },
        new Topping()
    {
        Id = 2,
        Name = "Chives"
    },
        new Topping()
    {
        Id = 3,
        Name = "Cheese"
    },
        new Topping()
    {
        Id = 4,
        Name = "Bacon"
    },
        new Topping()
    {
        Id = 5,
        Name = "Sour Cream"
    }
};

List <TuberOrder> tuberOrders = new List<TuberOrder>()
{
    new TuberOrder()
    {
        Id = 1,
        

    }

}
//add endpoints here
app.MapGet("/api/tuberorders", () =>
{
    return Results.Ok(
        orders.Select(o => new TuberOrderDTO()
        {
            Id = d.Id,
            Name = d.Name,
            CityId = d.CityId,
            WalkerId = d.WalkerId
        })
        .ToList()
    );

});

app.Run();
//don't touch or move this!
public partial class Program { }