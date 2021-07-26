using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitExpenses.Migrations
{
    public partial class columnsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaidParticipantId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidParticipantId",
                table: "Expenses");
        }
    }
}
