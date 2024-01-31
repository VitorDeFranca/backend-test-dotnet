using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteFCamara.Persistence.Migrations
{
    public partial class alteraçãonomecampoqtdVagasDisp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QtdVagasMoto",
                table: "Estabelecimentos",
                newName: "QtdVagasDispMoto");

            migrationBuilder.RenameColumn(
                name: "QtdVagasCarro",
                table: "Estabelecimentos",
                newName: "QtdVagasDispCarro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QtdVagasDispMoto",
                table: "Estabelecimentos",
                newName: "QtdVagasMoto");

            migrationBuilder.RenameColumn(
                name: "QtdVagasDispCarro",
                table: "Estabelecimentos",
                newName: "QtdVagasCarro");
        }
    }
}
