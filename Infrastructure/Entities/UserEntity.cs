

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class UserEntity
{
    /// <summary>
    /// For adding a user to the database 
    /// </summary>
    /// 
    [Key]
    public string Id { get; set; } = null!;
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    public string SecurityKey { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Bio { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Updated { get; set; }
    /// <summary>
    /// connection to addressentity (one adress per user)
    /// </summary>
    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }
}
