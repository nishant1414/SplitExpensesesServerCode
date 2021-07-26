using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitExpenses.Models
{
    public class ExpenseModel
    {
        public string Item { get; set; }
        public decimal Amount { get; set; }
        public int PaidParticipantId { get; set; }
        public List<int> ExpenseParticipants { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }
        public int GroupId { get; set; }

    }
}
