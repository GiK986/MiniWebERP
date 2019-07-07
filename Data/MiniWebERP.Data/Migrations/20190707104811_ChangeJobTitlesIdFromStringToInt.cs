namespace MiniWebERP.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeJobTitlesIdFromStringToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobTitles_JobTitleId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTitles",
                table: "JobTitles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JobTitles");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JobTitles")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTitles",
                table: "JobTitles",
                column: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "JobTitleId",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobTitles_JobTitleId",
                table: "Employees",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees",
                column: "JobTitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobTitles_JobTitleId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTitles",
                table: "JobTitles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JobTitles");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "JobTitles")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTitles",
                table: "JobTitles",
                column: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitleId",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobTitles_JobTitleId",
                table: "Employees",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees",
                column: "JobTitleId");
        }
    }
}
