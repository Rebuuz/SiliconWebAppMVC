
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<UserEntity>(options)
{
    ///registrating entities. User already added
    ///
    public DbSet<AddressEntity> Addresses { get; set; }
}
