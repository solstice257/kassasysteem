using Order.Microservice.Model;

namespace Order.Microservice.Data
{
    public interface IOrderDAL
    {
        public List<OrderModel> GetOrders();
        public List<OrderModel> AddOrder(List<OrderModel> orders);
        public List<OrderModel> DeleteOrder(int id);
    }
}
