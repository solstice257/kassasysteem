using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class MsgOrderModel
    {
        public int orderID { get; set; }
        public string orderName { get; set; }
        public int price { get; set; }
        public bool alcoholic { get; set; }
    }
}
