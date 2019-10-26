using Microsoft.EntityFrameworkCore.Migrations;

namespace Calculator.Migrations
{
    public partial class AddReferencesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MethodId",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_MethodId",
                table: "Reports",
                column: "MethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Methods_MethodId",
                table: "Reports",
                column: "MethodId",
                principalTable: "Methods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Methods_MethodId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_MethodId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "MethodId",
                table: "Reports");
        }
    }
}
