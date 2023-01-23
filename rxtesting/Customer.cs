using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rxtesting
{
    public class Customer
    {
        public string Name => "Riox ralol";
        public int Age => 34;

        public virtual int GetOrdersById(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException("id");

            return 11;
        }
    }

    public class LoyalCustomer : Customer
    {
        public int Discount { get; set; }
        public LoyalCustomer()
        {
            Discount = 10;
        }

        public override int GetOrdersById(string id)
        {
            return 101;
        }
    }

    public static class CustomerFactory
    {
        public static Customer CreateCustomerInstace(int orderCount)
        {
            return orderCount <= 100 ? new Customer() : new LoyalCustomer();
        }
    }


}
