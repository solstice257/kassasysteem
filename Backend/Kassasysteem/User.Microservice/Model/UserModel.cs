using System.ComponentModel.DataAnnotations;

namespace User.Microservice.Model
{
    public class UserModel
    {
        [Key]
        public string userPin { get; set; }
        public string userName { get; set; }
    }
}
