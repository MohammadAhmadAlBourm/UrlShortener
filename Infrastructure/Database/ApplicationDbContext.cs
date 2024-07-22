using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShortenedUrl>(builder =>
        {
            builder.Property(x => x.Code).HasMaxLength(7);
            builder.HasIndex(x => x.Code).IsUnique();
            builder.HasIndex(x => x.CreatedDate);
        });

        modelBuilder.Entity<User>(builder =>
        {
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Username).IsUnique();
        });

        modelBuilder.Entity<User>(builder =>
        {
            builder
            .HasMany(x => x.ShortenedUrls)
            .WithOne()
            .HasForeignKey(x => x.UserId);
        });

    }
}