using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitExpenses.Models
{
    public class SplitExpensecs
    {
       public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string WhoPaid { get; set; }
        public string ForWHom { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountToBePaid { get; set; }
        public string Remark { get; set; }
    }
}
