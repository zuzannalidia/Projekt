namespace Projekt.Models;

public class Contract
{
    public int Id { get; set; }
    public string SoftwareName { get; set; }
    public string Version { get; set; }
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Discount { get; set; }
    public bool IsPaid { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
}
