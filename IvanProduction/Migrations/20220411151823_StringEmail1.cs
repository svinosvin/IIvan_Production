using Microsoft.EntityFrameworkCore.Migrations;

namespace IvanProduction.Migrations
{
    public partial class StringEmail1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Admins",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Email",
                table: "Admins",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
