namespace rxtesting.tests
{
    public class NamesTests
    {

        [Fact]
        public void MakeFullname_ReturnsFullname()
        {
            var names = new Names();
            var result = names.MakeFullname("Riox", "ralol");
            Assert.Equal("riox ralol", result, ignoreCase: true);
            Assert.Contains("riox", result, StringComparison.CurrentCultureIgnoreCase);
        }

        [Fact]
        public void Nickname_MustBeNull()
        {
            var names = new Names();
            //names.Nickname = "";
            Assert.Null(names.Nickname);
        }

        [Fact]
        public void MakeFullname_AlwaysReturnsValue()
        {
            var names = new Names();
            var result = names.MakeFullname("riox", "ralol");

            //Assert.NotNull(result);
            //Assert.True(!String.IsNullOrEmpty(result));
            Assert.False(String.IsNullOrEmpty(result));
        }
    }
}
