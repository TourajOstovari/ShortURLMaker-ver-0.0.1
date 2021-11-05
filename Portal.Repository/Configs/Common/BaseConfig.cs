namespace Portal.Repository.Configs.Common
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Portal.Domain.Common;
    class BaseConfig : IEntityTypeConfiguration<Portal.Domain.Common.BaseInfo>
    {
        public void Configure(EntityTypeBuilder<BaseInfo> builder)
        {
            builder.HasKey(e => e.id);
            
        }
    }
}
