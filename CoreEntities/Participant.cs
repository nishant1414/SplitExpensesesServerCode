using SplitExpenses.BaseEntities;
using System;

namespace SplitExpenses.Entities
{
    public class Participant : BaseEntity
    {
        public string Name { get; set; }
        public string EmailId { get; set;}
        public long Mobile { get; set; }
        public DateTime DOB { get; set; }
        public string Remarks { get; set; }
        public int SecondMobile { get; set; }
        public Address Address { get; set; }
        public string ExtraInfo1 { get; set; }
        public string ExtraInfo2 { get; set; }
        public string ExtraInfo3 { get; set; }
        public string ExtraInfo4 { get; set; }
        public string ExtraInfo5 { get; set; }

    }
}
