using Microsoft.EntityFrameworkCore.Migrations;

namespace aplicacao_com_service.Migrations
{
    public partial class ClassChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Paciente",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Medico",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Convenio",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Convenio");
        }
    }
}
