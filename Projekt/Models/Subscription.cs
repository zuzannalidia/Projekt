namespace Projekt.Models;

public class Subscription
{
    public int Id { get; set; }
    public string ServiceName { get; set; }
    public string RenewalPeriod { get; set; } 
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime NextRenewalDate { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
}
