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

        builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(p => p.MiddleName).HasMaxLength(50).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Gender).IsRequired();
        builder.Property(p => p.BirthOfDate).IsRequired();
        builder.Property(p => p.Age).IsRequired();
        builder.Property(p => p.MobileNumber).HasMaxLength(50).IsRequired();

        builder.Property(p => p.Email).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Password).HasMaxLength(15).IsRequired();
        builder.Property(p => p.Username).HasMaxLength(50).IsRequired();

        builder.Property(p => p.IsActive).IsRequired();
        builder.Property(p => p.IsEmailVerified).IsRequired();
        builder.Property(p => p.IsMobileNumberVerified).IsRequired();
        builder.Property(p => p.IsBlocked).IsRequired();

    }
}