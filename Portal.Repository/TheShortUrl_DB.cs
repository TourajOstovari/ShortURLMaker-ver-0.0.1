
namespace Portal.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    public class TheShortUrl_DB:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(System.Configuration.ConfigurationManager.ConnectionStrings["SQLite"].ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new Configs.Common.BaseConfig());
            _ = modelBuilder.ApplyConfiguration(new Configs.URL.URLConfig());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Domain.Entities.URL.URLInfo> URLS { get; set; }
        public DbSet<Domain.Entities.User.UserInfo> USERS { get; set; }
    }
}
