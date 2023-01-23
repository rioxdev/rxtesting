using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rxtesting.tests
{
    public class PasswordValidationTests
    {

        [Fact]
        public void Validate_GivenLongerThan8Chars_ReturnsTrue()
        {
            var validator = new DefaultPasswordValidator();
            var pwd = GenerateString(7) + "A";
            var result = validator.Validate(pwd);
            Assert.True(result);
        }

        [Fact]
        public void Validate_GivenShorterThan8Chars_ReturnsFalse()
        {
            var validator = new DefaultPasswordValidator(); 
            var pwd = GenerateString(6) + "A";
            var result = validator.Validate(pwd);   
            Assert.False(result);
        }

        [Fact]
        public void Validate_GivenOneUppercase_ReturnsTrue()
        {
            var validator = new DefaultPasswordValidator();
            var pwd = GenerateString(14) + "A"; 
            var result = validator.Validate(pwd);
            Assert.True(result);
        }

        [Fact]
        public void Validate_GivenNoUppercase_ReturnsFalse()
        {
            var validator = new DefaultPasswordValidator();
            var pwd = GenerateString(19);
            var result = validator.Validate(pwd);
            Assert.False(result);
        }

        [Fact]
        public void Validate_GivenEmptyOrNullPassword_ReturnsFalse()
        {
            var validator = new DefaultPasswordValidator();
            string pwd = string.Empty;
            var result = validator.Validate(pwd);
            Assert.False(result);   
        }

        private string GenerateString(int length)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                sb.Append("a");
            }
            return sb.ToString();
        }

    }
}
