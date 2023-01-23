using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rxtesting.tests
{
    public class CustomerTests
    {
        [Fact]
        public void CheckNameNotEmpty()
        {
            var customer = new Customer();  
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        [Fact]  
        public void CheckAgeRangeValid()
        {
            var customer = new Customer();

            int minAge = 20;
            int maxAge = 50;

            Assert.InRange(customer.Age, minAge, maxAge);   
        }

        [Fact]
        public void GetOrdersById_ThrowsException()
        {
            var customer = new Customer();
            var details =  Assert.Throws<ArgumentNullException>(() => customer.GetOrdersById(null));
            Assert.Equal("id", details.ParamName);
        }

        [Fact]
        public void LoyalCustomerForOrderCountGT100()
        {
            var customer = CustomerFactory.CreateCustomerInstace(102);
            var loyalCustomer =   Assert.IsType<LoyalCustomer>(customer);
            Assert.Equal(10, loyalCustomer.Discount);
        }

        [Fact]
        public void CustomerForOrderCountLT100()
        {
            var customer= new Customer();   
            var cust = Assert.IsType<Customer>(customer);      
            
        }
    }
}
