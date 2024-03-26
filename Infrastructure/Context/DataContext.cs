using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<AddressEntity> Address { get; set; }
    public DbSet<UserEntity> Users { get; set; }
}
