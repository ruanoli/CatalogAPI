using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopularProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataDeCadastro, CategoriaId)" +
                "VALUES('Coca-Cola', 'Zero açúcar', '4.50', 'coca.jpg',210,now(), 1)");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataDeCadastro, CategoriaId)" +
                "VALUES('Trakinas', 'Limão', '2.20', 'trakinas.jpg',210,now(), 2)");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataDeCadastro, CategoriaId)" +
                "VALUES('Torrada de pão de forma', 'Torrada com manteiga', '10.00', 'torradaP.jpg',50,now(), 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Produtos");
        }
    }
}
