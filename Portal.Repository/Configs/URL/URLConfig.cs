namespace Portal.Repository.Configs.URL
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Portal.Domain.Entities.URL;
    public class URLConfig : IEntityTypeConfiguration<Portal.Domain.Entities.URL.URLInfo>
    {
        public void Configure(EntityTypeBuilder<URLInfo> builder)
        {
            builder.Property(e => e.MainUrl_).IsUnicode(true);
            builder.Property(z => z.Created).HasDefaultValueSql("GETDATE()");
            builder.Property(z => z.Visit).HasDefaultValue(0);
        }
    }
}
