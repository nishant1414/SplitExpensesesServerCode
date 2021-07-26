using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitExpenses.Models
{
    public class SignUpModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

    }
}
