using System.ComponentModel.DataAnnotations;

namespace Order.Microservice.Model
{
    public class OrderModel
    {
        [Key]
        public int orderID { get; set; }
        public string orderName { get; set; }
        public int price { get; set; }
        public bool alcoholic { get; set; } 
    }
}
