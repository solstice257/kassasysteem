namespace Walking_Skeleton_LOUPE.Model
{
    public class DataRepository : IDataRepository
    {
        private readonly UserDbContext db;

        public DataRepository(UserDbContext db)
        {
            this.db = db;
        }

        public List<User> GetUsers() => db.User.ToList();

        public User UpdateUser(User user)
        {
            db.User.Update(user);
            db.SaveChanges();
            return db.User.Where(x => x.UserId == user.UserId).FirstOrDefault();
        }

        public List<User> AddUser(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return db.User.ToList();
        }

        public User GetUserById(string id)
        {
            return db.User.Where(x => x.UserId == id).FirstOrDefault();
        }
    }
}
