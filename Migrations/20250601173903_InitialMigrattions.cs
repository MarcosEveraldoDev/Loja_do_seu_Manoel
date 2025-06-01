using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loja_do_Manuel.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrattions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dimensoes_Altura = table.Column<int>(type: "int", nullable: false),
                    Dimensoes_Largura = table.Column<int>(type: "int", nullable: false),
                    Dimensoes_Comprimento = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PedidoId",
                table: "Produtos",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
