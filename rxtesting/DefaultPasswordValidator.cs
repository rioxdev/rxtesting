using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rxtesting
{
    public class DefaultPasswordValidator : IPasswordValidator
    {
        public bool Validate(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            if (password.Length < 8) return false;

            if (!password.Any(c => char.IsUpper(c))) return false;

            return true;
        }
    }
}
