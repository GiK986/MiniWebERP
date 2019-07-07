namespace MiniWebERP.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddContactPersonEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContactPersonID",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ContactsPersons",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PreferredName = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsPersons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactPersonID",
                table: "Customers",
                column: "ContactPersonID",
                unique: true,
                filter: "[ContactPersonID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContactsPersons_IsDeleted",
                table: "ContactsPersons",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ContactsPersons_ContactPersonID",
                table: "Customers",
                column: "ContactPersonID",
                principalTable: "ContactsPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ContactsPersons_ContactPersonID",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "ContactsPersons");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ContactPersonID",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "ContactPersonID",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
