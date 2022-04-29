using Order.Microservice.Model;


namespace Order.Microservice.Data
{
    public class DataSeeder
    {
        private readonly OrderDbContext orderDbContext;

        public DataSeeder(OrderDbContext orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        public void Seed()
        {
            if (!orderDbContext.Order.Any())
            {
                var user = new List<OrderModel>()
                {
                    new OrderModel()
                    {
                        orderID = 11,
                        orderName = "Bier",
                        price = 3,
                        alcoholic = true
                    },
                    new OrderModel()
                    {
                        orderID = 22,
                        orderName = "Fris",
                        price = 3,
                        alcoholic = false
                    }
                };

                orderDbContext.Order.AddRange(user);
                orderDbContext.SaveChanges();
            }
        }

    }
}
