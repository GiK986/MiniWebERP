namespace MiniWebERP.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ModifiedCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Customers",
                newName: "DeliveryAddressLine2");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Customers",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Customers",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Customers",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonID",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddressLine1",
                table: "Customers",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCity",
                table: "Customers",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactPersonID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressLine1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeliveryCity",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddressLine2",
                table: "Customers",
                newName: "ContactName");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Customers",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                maxLength: 255,
                nullable: true);
        }
    }
}
