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

        public CalculatorTests(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }

        [Fact]
        public void Add_GivenTwoInt_ReturnsInt()
        {
            //Arrange
            var services = new ServiceCollection()
            .AddLogging((builder) => builder.AddXUnit(OutputHelper))
            .AddScoped<Calculator>();

            var calc = services
                .BuildServiceProvider()
                .GetRequiredService<Calculator>();

            //Act
            var result = calc.Add(1, 3);

            //Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Add_GivenTwoDoubles_ReturnsDouble()
        {
            var services = new ServiceCollection()
                .AddLogging((builder) => builder.AddXUnit(OutputHelper))
                .AddSingleton<Calculator>();

            var calc = services
                .BuildServiceProvider()
                .GetRequiredService<Calculator>();
            var result = calc.AddDouble(2.57, 5.21);
            Assert.Equal(7.8, result, 1);
        }

        [Theory]
        [InlineData(1, 3, 4)]
        [InlineData(10, 11, 21)]

        public void Add_TestIntValues(int a, int b, int expected)
        {
            var services = new ServiceCollection()
                .AddLogging((builder) => builder.AddXUnit(OutputHelper))
                .AddSingleton<Calculator>();

            var calc = services
                .BuildServiceProvider()
                .GetRequiredService<Calculator>();

            var result = calc.Add(a, b);

            result.Should().Be(expected);
        }
    }
}