using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopularModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, ImagemUrl)" +
                "Values ('Bebidas', 'bebidas.jpg')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, ImagemUrl)" +
                "Values ('Biscoitos', 'biscoitos.jpg')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, ImagemUrl)" +
                "Values ('Torrada', 'torrada.jpg')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Categorias");
        }
    }
}
