namespace MiniWebERP.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddEmployeeAplicationUserOneToOneRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AplicationUserId",
                table: "Employees",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_AplicationUserId",
                table: "Employees",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_AplicationUserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AplicationUserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Employees");
        }
    }
}
