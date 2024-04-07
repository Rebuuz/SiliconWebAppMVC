
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<UserEntity>(options)
{
    ///registrating entities. User already added
    ///
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CoursesEntity> Courses { get; set; }
    public DbSet<SubscribersEntity> Subscribers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserEntity>()
            .HasOne(u => u.Address)
            .WithMany(a => a.User)
            .HasForeignKey(u => u.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
