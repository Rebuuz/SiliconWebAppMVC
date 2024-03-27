namespace Infrastructure.Models;

public class AddressModel
{
    /// <summary>
    /// If I only want to use address, and not users as well 
    /// </summary
    public int Id { get; set; }
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
