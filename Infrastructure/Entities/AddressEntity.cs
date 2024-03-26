using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class AddressEntity
{
    ///for adding address information
    /// <summary>
    /// </summary>
    /// 
    [Key]
    public int Id { get; set; }
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    /// <summary>
    /// connection to userentity (many users on one adress)
    /// </summary>
    public ICollection<UserEntity> Users { get; set; } = [];

}
