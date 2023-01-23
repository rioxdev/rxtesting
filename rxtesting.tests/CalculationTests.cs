using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rxtesting.tests
{
    public class CalculationTests
    {
        [Fact]
        public void FiboNumbers_NotIncludesZero()
        {
            var calculations = new Calculations();

            Assert.All(calculations.FiboNumbers, (item) =>
            {
                Assert.NotEqual(0, item);
            });
        }

        [Fact]
        public void FiboNumbers_Includes13()
        {
            var calculations = new Calculations();
            Assert.Contains(13, calculations.FiboNumbers);
        }

        [Fact]
        public void FiboNumbers_NotIncludes4()
        {
            var calculations = new Calculations();
            Assert.DoesNotContain(4, calculations.FiboNumbers);
        }

        [Fact]
        public void CheckCollection()
        {
            List<int> excepted = new List<int>() { 1, 1, 2, 3, 5, 8, 13 };
            var calculations = new Calculations();
            Assert.Equal(excepted, calculations.FiboNumbers);
        }
    }
}
