namespace TuberTreats.Models.DTOs;

public class TuberOrderDTO 
{
    public int Id { get; set;}

    public DateTime TimeStamp { get; set; }

    public int CustomerId { get; set; }

    public int TuberDriverId {get; set; }

    public DateTime DeliveredOn { get; set;}

    public List<ToppingDTO> Toppings { get; set; }
}