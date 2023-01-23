namespace rxtesting.tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_GivenTwoInt_ReturnsInt()
        {
            //Asert
            var calc = new Calculator();

            //Act
            var result = calc.Add(1, 3);

            //Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Add_GivenTwoDoubles_ReturnsDouble()
        {
            var calc = new Calculator();
            var result = calc.AddDouble(2.57, 5.21);
            Assert.Equal(7.8, result, 1);
        }
    }
}