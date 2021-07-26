using SplitExpenses.BaseEntities;

namespace SplitExpenses.Entities
{
    public class Expense : BaseEntity
    {
        public string Item { get; set; }
        public ExpenseType TypeOfExpense { get; set; }
        public decimal Amount { get; set; }
        public string WhoPaid { get; set; }
        public int PaidParticipantId { get; set; }
        public int InvolveParticipants { get; set; }
        public int GroupId { get; set; }
        public string Remarks { get; set; }
        public PaymentType PaymentMethod { get; set; }
        public string ExtraInfo { get; set; }
        public string ExtraInfo1 { get; set; }
        public string ExtraInfo2 { get; set; }
    }

    public enum ExpenseType
    {
        Travel,
        Food,
        Education,
        Recharge,
        Others
    }

    public enum PaymentType
    {
        Cash,
        UPI,
        Wallet,
        DebitCard,
        CreditCard,
        Others
    }
}
