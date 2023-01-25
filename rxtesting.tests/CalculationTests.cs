using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace rxtesting.tests
{

    public class CalculationsFixture
    {
        public Calculations Calc => new Calculations();
    }

    public class CalculationTests : IClassFixture<CalculationsFixture>, IDisposable
    {
        private readonly CalculationsFixture _fixture;
        private readonly ITestOutputHelper _outputHelper;

        public CalculationTests(CalculationsFixture fixture, ITestOutputHelper outputHelper)
        {
            _fixture = fixture;
            _outputHelper = outputHelper;

            _outputHelper.WriteLine("executing constructor...");
        }
        public void Dispose()
        {
            _outputHelper.WriteLine("executing Dispose()...");
        }

        [Fact]
        public void FiboNumbers_NotIncludesZero()
        {
            _outputHelper.WriteLine("fibo does not include zero");
            // var calculations = new Calculations();

            // fixture version
            Assert.All(_fixture.Calc.FiboNumbers, (item) =>
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

        [Fact]
        public void IsOdd_GivenOddNumber_ReturnsTrue()
        {
            var calc = new Calculations();
            var result = calc.IsOdd(5);
            result.Should().BeTrue();
        }

        [Fact]
        public void IsOdd_GivenEvenNumber_ReturnsFalse()
        {
            var calc = new Calculations();
            var result = calc.IsOdd(20);
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(4, false)]
        public void IsOdd_GivenOddAndEven(int value, bool expected)
        {
            var calc = new Calculations();
            var result = calc.IsOdd(value);
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEven), MemberType = typeof(TestDataShare))]
        public void IsOdd_GivenSharedData(int value, bool expected)
        {
            var calc = new Calculations();
            var result = calc.IsOdd(value); 

            result.Should().Be(expected);   
        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsEvenOrOddExterna), MemberType = typeof(TestDataShare))]  
        public void IsOdd_GivenSharedExternalData(int value, bool expected)
        {
            var calc = new Calculations();
            var result = calc.IsOdd(value);
            
            result.Should().Be(expected);
        }

    }
}
