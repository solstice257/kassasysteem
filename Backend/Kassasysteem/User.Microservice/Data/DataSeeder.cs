using User.Microservice.Context;
using User.Microservice.Model;

namespace User.Microservice.Data
{
    public class DataSeeder
    {
        private readonly UserDbContext userDbContext;

        public DataSeeder (UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public void Seed()
        {
            if (!userDbContext.User.Any())
            {
                var user = new List<UserModel>()
                {
                    new UserModel()
                    {
                        userPin = "44",
                        userName = "Sem"
                    },
                    new UserModel()
                    {
                        userPin = "55",
                        userName = "Nahir"
                    }
                };

                userDbContext.User.AddRange(user);
                userDbContext.SaveChanges();
            }
        }
        
    }
}
