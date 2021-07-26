using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitExpenses.Models
{
    public class SplitGroupExpenses
    {
        public string GroupName { get; set; }
        public int GroupId { get; set; }
        public decimal Total { get; set; }
        public List<ParticipantExpenses> ParticipantExpenses { get; set; }
        
    }

    public class ParticipantExpenses
    { 
       public string ParticipantFrom { get; set; }
       public string ParticipantTo { get; set; }
       public decimal Amount { get; set; }
       public string Remarks { get; set; }
    }

}
