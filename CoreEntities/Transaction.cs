using SplitExpenses.BaseEntities;

namespace SplitExpenses.Entities
{
    public class Transaction : BaseEntity
    {
        public int ExpenseId { get; set; }
        public int GroupId { get; set; }
        public int PaidParticipantId { get; set; }
        public string PaidParticipantName { get; set; }
        public decimal TotalAmount { get; set; }
        public int ParticipantId { get; set; }
        public string ParticipantName { get; set; }
        public string GroupName { get; set; }
        public bool IsActive { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public string ExtraInfo { get; set; }
        public string ExtraInfo1 { get; set; }
        public string ExtraInfo2 { get; set; }
    }
}
