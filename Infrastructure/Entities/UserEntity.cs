﻿
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    /// <summary>
    /// For adding a user to the database, using identity.
    /// </summary>
    /// 
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }
}


