using User.Microservice.Model;

namespace User.Microservice.Data
{
    public interface IUserDAL
    {
        List<UserModel> AddUser(UserModel user);
        List<UserModel> GetUsers();
        UserModel UpdateUser(UserModel user);
        UserModel GetUserById(string id);
    }
}