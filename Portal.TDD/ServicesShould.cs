namespace Portal.TDD
{
    using Xunit;
    using Microsoft.EntityFrameworkCore;

    public class ServicesShould
    {
        [Fact]
        public void ShortURLGenerator()
        {
            // AAA
            // Arrange
            // Act
            // Assert
            //var DB_ = new DbContextOptionsBuilder<Repository.TheShortUrl_DB>().UseInMemoryDatabase("SQLite").Options;
            Repository.TheShortUrl_DB db = new Repository.TheShortUrl_DB();
            Portal.Services.Service service = new Services.Service(db);

            #region Model_Creating
            string url = "www.google.com";
            Services.CreateSURLMODEL create = new Services.CreateSURLMODEL();
            create.MAINURL = url; create.IPADDRESS = "1.1.1.1";
            #endregion


            Assert.NotNull(service.Create(create));
        } 
        [Fact]
        public void ShortURLGeneratorString()
        {
            //var DB_ = new DbContextOptionsBuilder<Repository.TheShortUrl_DB>().UseInMemoryDatabase("SQLite").Options;
            Repository.TheShortUrl_DB db = new Repository.TheShortUrl_DB();
            Portal.Services.Service service = new Services.Service(db);
            string url = "www.google.com";

            Services.CreateSURLMODEL create = new Services.CreateSURLMODEL();
            create.MAINURL = url; create.IPADDRESS = "1.1.1.1";

            Assert.IsType<System.Threading.Tasks.Task<string>>(service.Create(create));
            Assert.NotNull(service.Create(create));
        }
    }
}
