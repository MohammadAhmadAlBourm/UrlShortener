using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database;

internal sealed class UserConfiguration : EntityConfiguration<User>
{
    protected override void AppendConfig(EntityTypeBuilder<User> builder)
    {
        builder
            .HasMany(x => x.ShortenedUrls)
            .WithOne()
            .HasForeignKey(x => x.UserId);

        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.Username).IsUnique();

        builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Password).HasMaxLength(15).IsRequired();
        builder.Property(p => p.Salt).HasMaxLength(24).IsRequired();
        builder.Property(p => p.Username).HasMaxLength(50).IsRequired();
    }
}