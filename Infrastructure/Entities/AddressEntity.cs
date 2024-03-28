
namespace Infrastructure.Entities;

public class AddressEntity 
{
    public int Id { get; set; }
    public string? AddressOne { get; set; }
    public string? AddressTwo { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    public ICollection<UserEntity> User { get; set; } = [];
}
