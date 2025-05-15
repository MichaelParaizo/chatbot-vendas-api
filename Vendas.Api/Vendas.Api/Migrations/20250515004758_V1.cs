using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vendas.Api.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adicional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    valor = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adicional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forma = table.Column<int>(type: "int", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sabor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    tag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    valorAdicional = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    tipo = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sabor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tamanho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    valorBase = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tamanho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteId = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    observacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    pagamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedido_cliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_pagamento_pagamentoId",
                        column: x => x.pagamentoId,
                        principalTable: "pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedidoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pedidoId = table.Column<int>(type: "int", nullable: false),
                    produtoId = table.Column<int>(type: "int", nullable: false),
                    tamanhoId = table.Column<int>(type: "int", nullable: false),
                    observacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedidoItem_pedido_pedidoId",
                        column: x => x.pedidoId,
                        principalTable: "pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedidoItem_produto_produtoId",
                        column: x => x.produtoId,
                        principalTable: "produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedidoItem_tamanho_tamanhoId",
                        column: x => x.tamanhoId,
                        principalTable: "tamanho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedidoItemAdicional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pedidoItemId = table.Column<int>(type: "int", nullable: false),
                    adicionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidoItemAdicional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedidoItemAdicional_adicional_adicionalId",
                        column: x => x.adicionalId,
                        principalTable: "adicional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedidoItemAdicional_pedidoItem_pedidoItemId",
                        column: x => x.pedidoItemId,
                        principalTable: "pedidoItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedidoItemSabor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoItemId = table.Column<int>(type: "int", nullable: false),
                    SaborId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidoItemSabor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedidoItemSabor_pedidoItem_PedidoItemId",
                        column: x => x.PedidoItemId,
                        principalTable: "pedidoItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedidoItemSabor_sabor_SaborId",
                        column: x => x.SaborId,
                        principalTable: "sabor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "adicional",
                columns: new[] { "Id", "tipo", "titulo", "valor" },
                values: new object[,]
                {
                    { 1, "Borda Catupiry", "Borda", 2m },
                    { 2, "Borda Cream Cheese", "Borda", 2m },
                    { 3, "Borda Cheedar", "Borda", 2m }
                });

            migrationBuilder.InsertData(
                table: "sabor",
                columns: new[] { "Id", "descricao", "tag", "tipo", "titulo", "valorAdicional" },
                values: new object[,]
                {
                    { 1, "Mussarela e azeitonas", "queijo", 1m, "Mussarela", 0m },
                    { 2, "Mussarela, fatias de tomate e parmesão", "queijo", 1m, "Napolitana", 0m },
                    { 3, "Mussarela, tomate, manjericão fresco e parmesão", "queijo", 1m, "Marguerita", 0m },
                    { 4, "Mussarela, fatias de tomate, peperone, manjericão e parmesão", "queijo", 1m, "Marguerita com Peperone", 0m },
                    { 5, "Catupiry legítimo e azeitonas", "queijo", 1m, "Catupiry Legítimo", 0m },
                    { 6, "Mussarela e catupiry legítimo", "queijo", 1m, "2 Queijos", 0m },
                    { 7, "Mussarela, catupiry legítimo e provolone", "queijo", 1m, "3 Queijos", 0m },
                    { 8, "Mussarela, catupiry legítimo, provolone e parmesão", "queijo", 1m, "4 Queijos", 0m },
                    { 9, "Mussarela, catupiry legítimo, provolone, parmesão e gorgonzola", "queijo", 1m, "5 Queijos", 0m },
                    { 10, "Mussarela, parmesão e alho frito", "queijo", 1m, "Pomodoro", 0m },
                    { 11, "Frango, milho e mussarela", "frango", 1m, "Frango com Mussarela", 0m },
                    { 12, "Frango temperado com catupiry legítimo", "frango", 1m, "Frango com Catupiry", 0m },
                    { 13, "Frango temperado, bacon frito e provolone", "frango", 1m, "Frango com Provolone", 0m },
                    { 14, "Filé de frango temperado, milho no vapor e catupiry legítimo", "frango", 1m, "Caipira", 0m },
                    { 15, "Frango, milho, ervilha e mussarela", "frango", 1m, "Carijó", 0m },
                    { 16, "Frango, bacon frito e mussarela", "frango", 1m, "Jardineira", 0m },
                    { 17, "Frango, bacon, palmito, tomate, catupiry e mussarela", "frango", 1m, "Frango Especial", 0m },
                    { 18, "Calabresa moída, pimenta, ovos cozidos e cebola", "calabresa", 1m, "Baiana", 0m },
                    { 19, "Calabresa moída, tomate, cebola e parmesão", "calabresa", 1m, "Baiana Especial", 0m },
                    { 20, "Calabresa fatiada, cebola e azeitonas", "calabresa", 1m, "Calabresa", 0m },
                    { 21, "Calabresa fatiada e mussarela", "calabresa", 1m, "Calabresa com Mussarela", 0m },
                    { 22, "Calabresa fatiada, cebola e catupiry legítimo", "calabresa", 1m, "Calabresa com Catupiry Legítimo", 0m },
                    { 23, "Calabresa moída e mussarela", "calabresa", 1m, "Toscana", 0m },
                    { 24, "Calabresa moída, ovos cozidos, cebola e mussarela", "calabresa", 1m, "Toscana Especial", 0m },
                    { 25, "Atum sólido, cebola e azeitonas", "peixe", 1m, "Atum", 0m },
                    { 26, "Atum sólido, cebola, tomate e catupiry legítimo", "peixe", 1m, "Atum com Catupiry Legítimo", 0m },
                    { 27, "Atum sólido, cebola, tomate e mussarela", "peixe", 1m, "Atum com Mussarela", 0m },
                    { 28, "Atum sólido, bacon, cebola, ovos cozidos e mussarela", "peixe", 1m, "Brasileira", 0m },
                    { 29, "Atum sólido, palmito e mussarela", "peixe", 1m, "Americana", 0m },
                    { 30, "Atum sólido, palmito, ervilha e mussarela", "peixe", 1m, "Espanhola", 0m },
                    { 31, "Brócolis, atum e cobertura de mussarela", "especial", 1m, "Bella Castelli", 0m },
                    { 32, "Mussarela de búfala, tomate seco e rúcula", "especial", 1m, "Tomate Seco", 0m },
                    { 33, "Mussarela, tomate seco e rúcula", "especial", 1m, "Rúcula", 0m },
                    { 34, "Mussarela, peperone Sadia e parmesão", "especial", 1m, "Peperone", 0m },
                    { 35, "Brócolis, bacon e mussarela", "especial", 1m, "Brócolis", 0m },
                    { 36, "Brócolis, palmito e catupiry legítimo", "especial", 1m, "Brócolis com Catupiry Legítimo", 0m },
                    { 37, "Champignon temperado, bacon e mussarela", "especial", 1m, "Champignon", 0m },
                    { 38, "Carne seca, tomate, cebola e mussarela com toque de pimenta biquinho", "especial", 1m, "Carne Seca", 0m },
                    { 39, "Escarola, bacon e mussarela", "especial", 1m, "Escarola com Bacon", 0m },
                    { 40, "Mussarela, abacaxi em calda, hortelã e toque de canela", "especial", 1m, "Doce de Cid", 0m },
                    { 41, "Escarola, palmito, tomate, alho e mussarela", "especial", 1m, "Escarola Especial", 0m },
                    { 42, "Molho de tomate, parmesão e alho frito", "especial", 1m, "Alho", 0m },
                    { 43, "Milho coberto com mussarela e orégano", "especial", 1m, "Milho com Mussarela", 0m },
                    { 44, "Milho coberto com catupiry legítimo", "especial", 1m, "Milho com Catupiry Legítimo", 0m },
                    { 45, "Palmito fatiado com cobertura de mussarela", "especial", 1m, "Palmito", 0m },
                    { 46, "Champignon temperado, bacon, mussarela e alho frito", "especial", 1m, "Siciliana", 0m },
                    { 47, "Calabresa moída, frango, tomate e mussarela", "especial", 1m, "À Moda da Casa", 0m },
                    { 48, "Presunto, ovos cozidos, ervilhas, cebola e mussarela", "especial", 1m, "Portuguesa", 0m },
                    { 49, "Presunto, palmito, pimentão, cebola e mussarela", "especial", 1m, "Paulista", 0m },
                    { 50, "Presunto, ovos cozidos, bacon e mussarela", "especial", 1m, "Cowboy", 0m },
                    { 51, "1/4 Calabresa, 1/4 Mussarela, 1/4 Frango com catupiry e 1/4 Portuguesa", "especial", 1m, "Do Pizzaiolo", 0m },
                    { 52, "Presunto, tomate e mussarela", "especial", 1m, "Bauru", 0m },
                    { 53, "Calabresa fatiada, bacon, ovos, tomate e mussarela", "especial", 1m, "Calabria", 0m },
                    { 54, "Molho de tomate, selecionado, parmesão e azeitonas", "especial", 1m, "Aliche", 0m },
                    { 55, "Bacon frito e mussarela", "especial", 1m, "Bacon I", 0m },
                    { 56, "Presunto, ovos, cebola e bacon", "especial", 1m, "Bacon II", 0m },
                    { 57, "Presunto canadense, bacon e mussarela", "especial", 1m, "Italiana", 0m },
                    { 58, "Lombo tipo canadense e mussarela", "especial", 1m, "Lombo com Mussarela", 0m },
                    { 59, "Lombo tipo canadense e catupiry legítimo", "especial", 1m, "Lombo com Catupiry", 0m },
                    { 60, "Lombo tipo canadense, bacon, milho e provolone", "especial", 1m, "Padrão", 0m },
                    { 61, "Peito de peru, bacon frito, azeitonas e catupiry legítimo", "especial", 1m, "Peruana", 0m },
                    { 62, "Peito de peru, tomate, mussarela", "especial", 1m, "Peruana com Mussarela", 0m },
                    { 63, "Peito de peru, palmito, cebola e catupiry legítimo", "especial", 1m, "Francesa", 0m },
                    { 64, "Abobrinha, mussarela e alho frito", "especial", 1m, "Abobrinha", 0m },
                    { 65, "Abobrinha, alho poró, parmesão e cream cheese", "especial", 1m, "Abobrinha Especial", 0m },
                    { 66, "Brócolis, bacon, cebola e cream cheese", "especial", 1m, "Brócolis Especial", 0m },
                    { 67, "Peito de peru e cream cheese", "especial", 1m, "Philadelphia", 0m },
                    { 68, "Frango, bacon e cream cheese", "especial", 1m, "Frango c/ Cream Cheese", 0m },
                    { 69, "Filé mignon, mussarela, cebola, catupiry e alho frito salpicado", "especial", 1m, "Filé Mignon", 0m },
                    { 80, "Morango, chocolate e leite condensado", "doce", 1m, "Morango", 0m },
                    { 81, "Chocolate, banana com canela e leite condensado", "doce", 1m, "Banana", 0m },
                    { 82, "Chocolate, banana, canela e leite condensado", "doce", 1m, "Banana com Chocolate", 0m },
                    { 83, "Chocolate e granulado", "doce", 1m, "Chocolate", 0m },
                    { 84, "Nutella, castanha ou frutas (morango ou banana)", "doce", 1m, "Nutella", 0m },
                    { 85, "Nutella e M&M’s", "doce", 1m, "Nutella com MM’s", 0m },
                    { 86, "Chocolate e M&M’s", "doce", 1m, "Chocolate com MM’s", 0m },
                    { 87, "Nutella com castanha", "doce", 1m, "Nutella com Castanha", 0m },
                    { 88, "Esfiha aberta de carne temperada", "carne", 2m, "Carne", 0m },
                    { 89, "Esfiha aberta com queijo derretido", "queijo", 2m, "Queijo", 0m },
                    { 90, "Calabresa fatiada e levemente apimentada", "calabresa", 2m, "Calabresa", 0m },
                    { 91, "Frango desfiado com catupiry cremoso", "frango", 2m, "Frango com Catupiry", 0m },
                    { 92, "Presunto, queijo e tomate", "presunto", 2m, "Bauru", 0m },
                    { 93, "Atum temperado com leve toque de limão", "atum", 2m, "Atum", 0m },
                    { 94, "Atum temperado e queijo derretido", "atum", 2m, "Atum com Queijo", 0m },
                    { 95, "Palmito picado com queijo", "palmito", 2m, "Palmito com Queijo", 0m },
                    { 96, "Palmito com catupiry cremoso", "palmito", 2m, "Palmito com Catupiry", 0m },
                    { 97, "Escarola refogada com queijo", "vegetariana", 2m, "Escarola com Queijo", 0m },
                    { 98, "Calabresa e queijo derretido", "calabresa", 2m, "Calabresa com Queijo", 0m },
                    { 99, "Calabresa com catupiry cremoso", "calabresa", 2m, "Calabresa com Catupiry", 0m },
                    { 100, "Milho verde com queijo derretido", "vegetariana", 2m, "Milho com Queijo", 0m },
                    { 101, "Milho verde com catupiry", "vegetariana", 2m, "Milho Catupiry", 0m },
                    { 102, "Bacon crocante e queijo derretido", "bacon", 2m, "Bacon com Queijo", 0m },
                    { 103, "Mistura de queijos derretidos", "queijo", 2m, "Dois Queijos", 0m },
                    { 104, "Carne temperada com queijo", "carne", 2m, "Carne com Queijo", 0m },
                    { 105, "Brócolis refogado com queijo", "vegetariana", 2m, "Brócolis com Queijo", 0m },
                    { 106, "Pepperone levemente picante com queijo", "pepperone", 2m, "Pepperone", 0m },
                    { 107, "Carne seca desfiada com queijo", "carne", 2m, "Carne Seca com Queijo", 0m },
                    { 108, "Carne seca desfiada com catupiry", "carne", 2m, "Carne Seca com Catupiry", 0m },
                    { 109, "Esfiha aberta apenas com catupiry", "queijo", 2m, "Catupiry", 0m },
                    { 110, "Esfiha aberta de carne temperada", "carne", 2m, "Carne", 0m },
                    { 111, "Esfiha aberta com queijo derretido", "queijo", 2m, "Queijo", 0m },
                    { 112, "Calabresa fatiada e levemente apimentada", "calabresa", 2m, "Calabresa", 0m },
                    { 113, "Frango desfiado com catupiry cremoso", "frango", 2m, "Frango com Catupiry", 0m },
                    { 114, "Presunto, queijo e tomate", "presunto", 2m, "Bauru", 0m },
                    { 115, "Atum temperado com leve toque de limão", "atum", 2m, "Atum", 0m },
                    { 116, "Atum temperado e queijo derretido", "atum", 2m, "Atum com Queijo", 0m },
                    { 117, "Palmito picado com queijo", "palmito", 2m, "Palmito com Queijo", 0m },
                    { 118, "Palmito com catupiry cremoso", "palmito", 2m, "Palmito com Catupiry", 0m },
                    { 119, "Escarola refogada com queijo", "vegetariana", 2m, "Escarola com Queijo", 0m },
                    { 120, "Calabresa e queijo derretido", "calabresa", 2m, "Calabresa com Queijo", 0m },
                    { 121, "Calabresa com catupiry cremoso", "calabresa", 2m, "Calabresa com Catupiry", 0m },
                    { 122, "Milho verde com queijo derretido", "vegetariana", 2m, "Milho com Queijo", 0m },
                    { 123, "Milho verde com catupiry", "vegetariana", 2m, "Milho Catupiry", 0m },
                    { 124, "Bacon crocante e queijo derretido", "bacon", 2m, "Bacon com Queijo", 0m },
                    { 125, "Mistura de queijos derretidos", "queijo", 2m, "Dois Queijos", 0m },
                    { 126, "Carne temperada com queijo", "carne", 2m, "Carne com Queijo", 0m },
                    { 127, "Brócolis refogado com queijo", "vegetariana", 2m, "Brócolis com Queijo", 0m },
                    { 128, "Pepperone levemente picante com queijo", "pepperone", 2m, "Pepperone", 0m },
                    { 129, "Carne seca desfiada com queijo", "carne", 2m, "Carne Seca com Queijo", 0m },
                    { 130, "Carne seca desfiada com catupiry", "carne", 2m, "Carne Seca com Catupiry", 0m },
                    { 131, "Esfiha aberta apenas com catupiry", "queijo", 2m, "Catupiry", 0m },
                    { 132, "Chocolate cremoso com granulado", "chocolate", 2m, "Chocolate com Granulado", 0m },
                    { 133, "Chocolate com pedaços de morango", "chocolate", 2m, "Chocolate com Morango", 0m },
                    { 134, "Chocolate com rodelas de banana", "chocolate", 2m, "Chocolate com Banana", 0m },
                    { 135, "Esfiha doce recheada com Nutella", "nutella", 2m, "Nutella", 0m },
                    { 136, "Nutella com cobertura de M&M's", "nutella", 2m, "Nutella com M&M's", 0m },
                    { 137, "Chocolate cremoso com M&M's", "chocolate", 2m, "Chocolate com M&M's", 0m },
                    { 138, "Banana com cobertura de leite condensado", "banana", 2m, "Banana com Leite Condensado", 0m },
                    { 139, "Chocolate com pedaços de castanha", "chocolate", 2m, "Chocolate com Castanha", 0m },
                    { 140, "Nutella com castanhas crocantes", "nutella", 2m, "Nutella com Castanha", 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_pedido_clienteId",
                table: "pedido",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_pagamentoId",
                table: "pedido",
                column: "pagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidoItem_pedidoId",
                table: "pedidoItem",
                column: "pedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidoItem_produtoId",
                table: "pedidoItem",
                column: "produtoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidoItem_tamanhoId",
                table: "pedidoItem",
                column: "tamanhoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidoItemAdicional_adicionalId",
                table: "pedidoItemAdicional",
                column: "adicionalId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidoItemAdicional_pedidoItemId",
                table: "pedidoItemAdicional",
                column: "pedidoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidoItemSabor_PedidoItemId",
                table: "pedidoItemSabor",
                column: "PedidoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidoItemSabor_SaborId",
                table: "pedidoItemSabor",
                column: "SaborId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pedidoItemAdicional");

            migrationBuilder.DropTable(
                name: "pedidoItemSabor");

            migrationBuilder.DropTable(
                name: "adicional");

            migrationBuilder.DropTable(
                name: "pedidoItem");

            migrationBuilder.DropTable(
                name: "sabor");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "tamanho");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "pagamento");
        }
    }
}
