
namespace Walking_Skeleton_LOUPE.Model
{
    public interface IDataRepository
    {
        List<User> AddUser(User user);
        List<User> GetUsers();
        User UpdateUser(User user);
        User GetUserById(string id);
    }
}