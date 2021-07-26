using SplitExpenses.BaseEntities;

namespace SplitExpenses.Entities
{
    public class Address : BaseEntity
    { 
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string LandMark { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Zipcode { get; set; }
        public long Mobile { get; set; }
        public string Remarks { get; set; }

    }
}
