using Microsoft.EntityFrameworkCore.Migrations;

namespace SplitExpenses.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ExtraInfo4",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraInfo5",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "adminParticipantId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExtraInfo",
                table: "GroupParticipantExpenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraInfo1",
                table: "GroupParticipantExpenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraInfo2",
                table: "GroupParticipantExpenses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraInfo4",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ExtraInfo5",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "adminParticipantId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ExtraInfo",
                table: "GroupParticipantExpenses");

            migrationBuilder.DropColumn(
                name: "ExtraInfo1",
                table: "GroupParticipantExpenses");

            migrationBuilder.DropColumn(
                name: "ExtraInfo2",
                table: "GroupParticipantExpenses");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
