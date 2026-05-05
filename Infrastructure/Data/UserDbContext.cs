using Eventide.UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eventide.UserService.Infrastructure.Data;

public class UserDbContext : DbContext
{
    public DbSet<UserProfile> Profiles => Set<UserProfile>();

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserProfile>(builder =>
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Username).IsRequired().HasMaxLength(30);
            builder.HasIndex(p => p.Username).IsUnique();
            builder.HasIndex(p => p.AuthUserId).IsUnique();
            builder.Property(p => p.DisplayName).IsRequired().HasMaxLength(50);
            
            builder.Ignore(p => p.GameRanks);
            builder.Ignore(p => p.TeamIds);
        });
    }
}