using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rxtesting
{
    public class Names
    {
        public string Nickname { get; set; }

        public string MakeFullname(string firstname, string lastname) =>
            $"{firstname} {lastname}";
    }
}
