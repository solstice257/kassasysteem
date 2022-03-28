namespace Walking_Skeleton_LOUPE.Model
{
    public class DataSeeder
    {
        private readonly UserDbContext userDbContext;

        public DataSeeder(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public void Seed()
        {
            if (!userDbContext.User.Any())
            {
                var users = new List<User>()
                {
                    new User()
                    {
                        Name = "Roeland",
                        Citizenship = "Dutch",
                        UserId = "1"
                    },
                    new User()
                    {
                        Name = "Wesley",
                        Citizenship = "Dutch",
                        UserId = "2"
                    }
                };
                userDbContext.User.AddRange(users);
                userDbContext.SaveChanges();
            }
        }
    }
}
