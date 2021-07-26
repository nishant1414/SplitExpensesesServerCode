using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SplitExpenses.Models
{
    public class SignInModel
    {
        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
