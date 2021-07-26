using SplitExpenses.BaseEntities;

namespace SplitExpenses.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public string Purpose { get; set; }
        public Type Type { get; set; }
        public int adminParticipantId { get; set; }
        public string Remarks { get; set; }
        public string ExtraInfo { get; set; }
        public string ExtraInfo1 { get; set; }
        public string ExtraInfo2 { get; set; }
    }
    public enum Type
    {
        Friendly,Official,Temporary,Personal
    }
}
