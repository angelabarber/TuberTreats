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
        Address = "1492 Columbus Drive",
    },
     new Customer()
    {
        Id = 4,
        Name = "Bonnie",
        Address = "79 Vesuvius Lane",
    },
     new Customer()
    {
        Id = 5,
        Name = "Hank",
        Address = "61 Chaos Way",
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
        CustomerId = 1,
        TuberDriverId = 2
    },
        new TuberOrder()
    {
        Id = 2,
        CustomerId = 4,
        TuberDriverId = 1
    },
        new TuberOrder()
    {
        Id = 3,
        CustomerId = 1,
        TuberDriverId = 2
    }

};
//add endpoints here
app.MapGet("/api/tuberorders", () =>
{
    return Results.Ok(
        tuberOrders.Select(o => new TuberOrderDTO()
        {
            Id = o.Id,
            OrderPlacedOnDate = o.OrderPlacedOnDate,
            CustomerId = o.CustomerId,
            TuberDriverId = o.TuberDriverId,
            DeliveredOnDate = o.DeliveredOnDate,
            Toppings = o.Toppings.Select(t => new ToppingDTO
            {
                Id = t.Id,
                Name = t.Name
            }). ToList()
        })
        .ToList()
    );

});

app.MapGet("/api/tuberorders/{id}", (int id) =>
{
    TuberOrder order = tuberOrders.FirstOrDefault(o => o.Id == id);

    if (order == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(
        new TuberOrderDTO()
        {
            Id = order.Id,
            OrderPlacedOnDate = order.OrderPlacedOnDate,
            CustomerId = order.CustomerId,
            TuberDriverId = order.TuberDriverId,
            DeliveredOnDate = order.DeliveredOnDate,
            Toppings = order.Toppings
                .Select(t => new ToppingDTO()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList()
        }
    );
});

app.MapPost("/api/tuberorders", (TuberOrderDTO newOrderDTO) =>
{
    TuberOrder newOrder = new TuberOrder
    {
        Id = tuberOrders.Count > 0 ? tuberOrders.Max(o => o.Id) + 1 : 1, 
        OrderPlacedOnDate = DateTime.UtcNow, 
        CustomerId = newOrderDTO.CustomerId,
        TuberDriverId = newOrderDTO.TuberDriverId,
        DeliveredOnDate = newOrderDTO.DeliveredOnDate,
        Toppings = newOrderDTO.Toppings.Select(t => new ToppingDTO
        {
            Id = t.Id,
            Name = t.Name
        }).ToList()
    };


    tuberOrders.Add(newOrder);

    return Results.Ok(new TuberOrderDTO
    {
        Id = newOrder.Id,
        OrderPlacedOnDate = newOrder.OrderPlacedOnDate,
        CustomerId = newOrder.CustomerId,
        TuberDriverId = newOrder.TuberDriverId,
        DeliveredOnDate = newOrder.DeliveredOnDate,
        Toppings = newOrder.Toppings.Select(t => new ToppingDTO
        {
            Id = t.Id,
            Name = t.Name
        }).ToList()
    });
});

app.MapPut("/api/tuberorders/{id}", (int id, int? tuberDriverId) =>
{
    TuberOrder order = tuberOrders.FirstOrDefault(o => o.Id == id);

    if (order == null)
    {
        return Results.NotFound();
    }

    order.TuberDriverId = tuberDriverId;

 
    return Results.Ok(new TuberOrderDTO
    {
        Id = order.Id,
        OrderPlacedOnDate = order.OrderPlacedOnDate,
        CustomerId = order.CustomerId,
        TuberDriverId = order.TuberDriverId,
        DeliveredOnDate = order.DeliveredOnDate,
        Toppings = order.Toppings.Select(t => new ToppingDTO
        {
            Id = t.Id,
            Name = t.Name
        }).ToList()
    });
});





app.MapGet("/api/toppings", () =>
{
    return Results.Ok(
        toppings.Select(t => new ToppingDTO()
        {
            Id = t.Id,
            Name = t.Name,
        })
        .ToList()
    );

});


app.MapGet("/api/toppings/{id}", (int id) => 
{
    Topping topping = toppings.FirstOrDefault( t => t.Id == id);

    if(topping != null)
    {
        return Results.Ok(topping);
    }
    else
    {
        return Results.NotFound();
    }
});

app.Run();
//don't touch or move this!
public partial class Program { }