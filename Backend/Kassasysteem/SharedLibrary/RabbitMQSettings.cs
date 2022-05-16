using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class RabbitMQSettings
    {
        public string userName = "guest";
        public string password = "guest";
        public string url = "192.168.222.128:5672";
        public string queueName = "OrderQueue";
    }
}
