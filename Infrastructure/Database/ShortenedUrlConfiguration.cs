using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database;

internal sealed class ShortenedUrlConfiguration : EntityConfiguration<ShortenedUrl>
{
    protected override void AppendConfig(EntityTypeBuilder<ShortenedUrl> builder)
    {
        builder.Property(x => x.Code).HasMaxLength(7);

        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.CreatedDate);
    }
}