using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Microservice.Data;
using User.Microservice.Model;

namespace User.Microservice.Test.Stubs
{
    internal class UserDALStub : IUserDAL
    {
        public bool? testValue = null;

        public List<UserModel> AddUser(UserModel user)
        {
            if (testValue == true)
            {
                return new List<UserModel>();
            }
            else
            {
                return null;
            }
        }

        public List<UserModel> GetUsers()
        {
            if (testValue == true)
            {
                return new List<UserModel>();
            }
            else
            {
                return null;
            }

        }

        public UserModel UpdateUser(UserModel user)
        {
            if (testValue == true)
            {
                return new UserModel();
            }
            else
            {
                return null;
            }
        }

        public UserModel GetUserById(string id)
        {
            return new UserModel();
        }
    }
}
