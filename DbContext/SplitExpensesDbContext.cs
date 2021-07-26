using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SplitExpenses.Entities;

namespace SplitExpenses
{
    public class SplitExpensesDbContext : IdentityDbContext
    {
        public SplitExpensesDbContext(DbContextOptions<SplitExpensesDbContext> options) 
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //entities
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<GroupParticipant> GroupParticipantExpenses { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
