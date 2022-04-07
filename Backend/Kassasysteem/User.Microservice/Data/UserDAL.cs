using User.Microservice.Context;
using User.Microservice.Model;

namespace User.Microservice.Data
{
    public class UserDAL : IUserDAL
    {
        private readonly UserDbContext db;

        public UserDAL(UserDbContext db)
        {
            this.db = db;
        }

        public List<UserModel> GetUsers() => db.User.ToList();

        public UserModel UpdateUser(UserModel user)
        {
            db.User.Update(user);
            db.SaveChanges();
            return db.User.Where(x => x.userPin == user.userPin).FirstOrDefault();
        }

        public List<UserModel> AddUser(UserModel user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return db.User.ToList();
        }

        public UserModel GetUserById(string id)
        {
            return db.User.Where(x => x.userPin == id).FirstOrDefault();
        }
    }
}
