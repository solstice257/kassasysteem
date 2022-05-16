using Order.Microservice.Data;
using Order.Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Microservice.Test.Stubs
{
    internal class OrderDALStub : IOrderDAL
    {
        public bool? testValue = null;
        public List<OrderModel> AddOrder(List<OrderModel> orders)
        {
            if (testValue == true)
            {
                return new List<OrderModel>();
            }
            else
            {
                return null;
            }
        }

        public List<OrderModel> DeleteOrder(int id)
        {
            if (testValue == true)
            {
                return new List<OrderModel>();
            }
            else
            {
                return null;
            }
        }

        public List<OrderModel> GetOrders()
        {
            if (testValue == true)
            {
                return new List<OrderModel>();
            }
            else
            {
                return null;
            }
        }
    }
}
