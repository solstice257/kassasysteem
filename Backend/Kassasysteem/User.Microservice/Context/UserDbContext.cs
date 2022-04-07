using Microsoft.EntityFrameworkCore;
using User.Microservice.Model;

namespace User.Microservice.Context
{
    public class UserDbContext : DbContext
    {

        public UserDbContext()
        {

        }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var confuguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = confuguration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
