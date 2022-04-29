using Order.Microservice.Model;

namespace Order.Microservice.Data
{
    public class OrderDAL : IOrderDAL
    {
        private readonly OrderDbContext db;

        public OrderDAL (OrderDbContext db)
        {
            this.db = db;
        }

        public List<OrderModel> GetOrders() => db.Order.ToList();


        public List<OrderModel> AddOrder(List<OrderModel> orders)
        {
            foreach (OrderModel order in orders)
            {
                db.Order.Add(order);
            }
            db.SaveChanges();
            return db.Order.ToList();
        }

        public List<OrderModel> DeleteOrder(int id)
        {
            db.Order.Remove(db.Order.Where(x => x.orderID == id).FirstOrDefault());
            db.SaveChanges();
            return db.Order.ToList();
        }
    }
}
