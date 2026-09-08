using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RiftRpg.Migrations
{
    /// <inheritdoc />
    public partial class CriadaFichaDePersonagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fichas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUsuario = table.Column<int>(type: "integer", nullable: false),
                    NomePersonagem = table.Column<string>(type: "text", nullable: false),
                    Nivel = table.Column<int>(type: "integer", nullable: false),
                    PontosVidaMax = table.Column<int>(type: "integer", nullable: false),
                    PontosVidaAtual = table.Column<int>(type: "integer", nullable: false),
                    PontosManaMax = table.Column<int>(type: "integer", nullable: false),
                    PontosManaAtual = table.Column<int>(type: "integer", nullable: false),
                    Despertar = table.Column<string>(type: "text", nullable: false),
                    Estilo = table.Column<string>(type: "text", nullable: false),
                    FotoUrl = table.Column<string>(type: "text", nullable: false),
                    Forca = table.Column<int>(type: "integer", nullable: false),
                    Destreza = table.Column<int>(type: "integer", nullable: false),
                    Constituicao = table.Column<int>(type: "integer", nullable: false),
                    Intelecto = table.Column<int>(type: "integer", nullable: false),
                    Poder = table.Column<int>(type: "integer", nullable: false),
                    Lutar = table.Column<int>(type: "integer", nullable: false),
                    Ocultismo = table.Column<int>(type: "integer", nullable: false),
                    ArmasBrancas = table.Column<int>(type: "integer", nullable: false),
                    Pontaria = table.Column<int>(type: "integer", nullable: false),
                    Robustez = table.Column<int>(type: "integer", nullable: false),
                    Crime = table.Column<int>(type: "integer", nullable: false),
                    Atletismo = table.Column<int>(type: "integer", nullable: false),
                    Furtividade = table.Column<int>(type: "integer", nullable: false),
                    Intimidacao = table.Column<int>(type: "integer", nullable: false),
                    Percepcao = table.Column<int>(type: "integer", nullable: false),
                    Psicologia = table.Column<int>(type: "integer", nullable: false),
                    Reflexos = table.Column<int>(type: "integer", nullable: false),
                    Acrobacias = table.Column<int>(type: "integer", nullable: false),
                    Iniciativa = table.Column<int>(type: "integer", nullable: false),
                    Vontade = table.Column<int>(type: "integer", nullable: false),
                    Labia = table.Column<int>(type: "integer", nullable: false),
                    Domar = table.Column<int>(type: "integer", nullable: false),
                    Conhecimento = table.Column<int>(type: "integer", nullable: false),
                    Intuicao = table.Column<int>(type: "integer", nullable: false),
                    Investigacao = table.Column<int>(type: "integer", nullable: false),
                    Medicina = table.Column<int>(type: "integer", nullable: false),
                    Direcao = table.Column<int>(type: "integer", nullable: false),
                    Sobrevivencia = table.Column<int>(type: "integer", nullable: false),
                    Habilidades = table.Column<string>(type: "text", nullable: false),
                    Anotacoes = table.Column<string>(type: "text", nullable: false),
                    Equipamentos = table.Column<string>(type: "text", nullable: false),
                    Historia = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fichas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventarioFichas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdFicha = table.Column<int>(type: "integer", nullable: false),
                    FichaId = table.Column<int>(type: "integer", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Peso = table.Column<int>(type: "integer", nullable: true),
                    Equipado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioFichas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventarioFichas_Fichas_FichaId",
                        column: x => x.FichaId,
                        principalTable: "Fichas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventarioFichas_FichaId",
                table: "InventarioFichas",
                column: "FichaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventarioFichas");

            migrationBuilder.DropTable(
                name: "Fichas");
        }
    }
}
