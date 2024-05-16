using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CriarBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fornecedor",
                columns: table => new
                {
                    fornecedorid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomefantasia = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    situacao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FornecedorModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedor", x => x.fornecedorid);
                    table.ForeignKey(
                        name: "FK_fornecedor_fornecedor_FornecedorModelId",
                        column: x => x.FornecedorModelId,
                        principalTable: "fornecedor",
                        principalColumn: "fornecedorid");
                });

            migrationBuilder.CreateTable(
                name: "orcamento",
                columns: table => new
                {
                    orcamentoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    anoorcamento = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    valororcamento = table.Column<double>(type: "double precision", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orcamento", x => x.orcamentoid);
                });

            migrationBuilder.CreateTable(
                name: "secretaria",
                columns: table => new
                {
                    secretariaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    situacao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SecretariaModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_secretaria", x => x.secretariaid);
                    table.ForeignKey(
                        name: "FK_secretaria_secretaria_SecretariaModelId",
                        column: x => x.SecretariaModelId,
                        principalTable: "secretaria",
                        principalColumn: "secretariaid");
                });

            migrationBuilder.CreateTable(
                name: "tipoinstituicao",
                columns: table => new
                {
                    tipoinstituicaoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipoinstituicao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TipoInstituicaoModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoinstituicao", x => x.tipoinstituicaoid);
                    table.ForeignKey(
                        name: "FK_tipoinstituicao_tipoinstituicao_TipoInstituicaoModelId",
                        column: x => x.TipoInstituicaoModelId,
                        principalTable: "tipoinstituicao",
                        principalColumn: "tipoinstituicaoid");
                });

            migrationBuilder.CreateTable(
                name: "tipousuario",
                columns: table => new
                {
                    tipousuarioid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    permitelogin = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipousuario", x => x.tipousuarioid);
                });

            migrationBuilder.CreateTable(
                name: "unidademedida",
                columns: table => new
                {
                    unidademedidaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descrição = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    abreviatura = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UnidadeMedidaModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidademedida", x => x.unidademedidaid);
                    table.ForeignKey(
                        name: "FK_unidademedida_unidademedida_UnidadeMedidaModelId",
                        column: x => x.UnidadeMedidaModelId,
                        principalTable: "unidademedida",
                        principalColumn: "unidademedidaid");
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    usuarioid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpfcnpj = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    nomerazaosocial = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    rgle = table.Column<int>(type: "integer", nullable: false),
                    logradouro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cep = table.Column<int>(type: "integer", nullable: false),
                    bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    rua = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    senha = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    situacao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    matricula = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.usuarioid);
                });

            migrationBuilder.CreateTable(
                name: "unidadeconsumidora",
                columns: table => new
                {
                    unidadeconsumidoraid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    unidadeconsumidora = table.Column<int>(type: "integer", nullable: false),
                    fornecedorid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidadeconsumidora", x => x.unidadeconsumidoraid);
                    table.ForeignKey(
                        name: "FK_unidadeconsumidora_fornecedor_fornecedorid",
                        column: x => x.fornecedorid,
                        principalTable: "fornecedor",
                        principalColumn: "fornecedorid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "instituicao",
                columns: table => new
                {
                    instituicaoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    situacao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tipoinstituicaoid = table.Column<int>(type: "integer", nullable: false),
                    secretariaid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instituicao", x => x.instituicaoid);
                    table.ForeignKey(
                        name: "FK_instituicao_secretaria_secretariaid",
                        column: x => x.secretariaid,
                        principalTable: "secretaria",
                        principalColumn: "secretariaid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_instituicao_tipoinstituicao_tipoinstituicaoid",
                        column: x => x.tipoinstituicaoid,
                        principalTable: "tipoinstituicao",
                        principalColumn: "tipoinstituicaoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tipodespesa",
                columns: table => new
                {
                    tipodespesaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipodespesa = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    solicitauc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    unidademedidaid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipodespesa", x => x.tipodespesaid);
                    table.ForeignKey(
                        name: "FK_tipodespesa_unidademedida_unidademedidaid",
                        column: x => x.unidademedidaid,
                        principalTable: "unidademedida",
                        principalColumn: "unidademedidaid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_FornecedorModelId",
                table: "fornecedor",
                column: "FornecedorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_instituicao_secretariaid",
                table: "instituicao",
                column: "secretariaid");

            migrationBuilder.CreateIndex(
                name: "IX_instituicao_tipoinstituicaoid",
                table: "instituicao",
                column: "tipoinstituicaoid");

            migrationBuilder.CreateIndex(
                name: "IX_secretaria_SecretariaModelId",
                table: "secretaria",
                column: "SecretariaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_tipodespesa_unidademedidaid",
                table: "tipodespesa",
                column: "unidademedidaid");

            migrationBuilder.CreateIndex(
                name: "IX_tipoinstituicao_TipoInstituicaoModelId",
                table: "tipoinstituicao",
                column: "TipoInstituicaoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_unidadeconsumidora_fornecedorid",
                table: "unidadeconsumidora",
                column: "fornecedorid");

            migrationBuilder.CreateIndex(
                name: "IX_unidademedida_UnidadeMedidaModelId",
                table: "unidademedida",
                column: "UnidadeMedidaModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "instituicao");

            migrationBuilder.DropTable(
                name: "orcamento");

            migrationBuilder.DropTable(
                name: "tipodespesa");

            migrationBuilder.DropTable(
                name: "tipousuario");

            migrationBuilder.DropTable(
                name: "unidadeconsumidora");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "secretaria");

            migrationBuilder.DropTable(
                name: "tipoinstituicao");

            migrationBuilder.DropTable(
                name: "unidademedida");

            migrationBuilder.DropTable(
                name: "fornecedor");
        }
    }
}
