using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace rxtesting.tests
{
    public class CalculatorTests
    {
        private ITestOutputHelper OutputHelper { get; }
        private Calculator _calc;

        public CalculatorTests(ITestOutputHelper outputHelper)
        {
            //Arrange

            OutputHelper = outputHelper;
            var services = new ServiceCollection()
                .AddLogging((builder) => builder.AddXUnit(OutputHelper))
                .AddScoped<Calculator>();

            _calc = services.BuildServiceProvider()
                .GetRequiredService<Calculator>();
        }

        [Fact]
        public void Add_GivenTwoInt_ReturnsInt()
        {
            //Act
            var result = _calc.Add(1, 3);

            //Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Add_GivenTwoDoubles_ReturnsDouble()
        {
            var result = _calc.AddDouble(2.57, 5.21);
            Assert.Equal(7.8, result, 1);
        }

        [Theory]
        [InlineData(1, 3, 4)]
        [InlineData(10, 11, 21)]

        public void Add_TestIntValues(int a, int b, int expected)
        {
            var result = _calc.Add(a, b);

            result.Should().Be(expected);
        }
    }
}