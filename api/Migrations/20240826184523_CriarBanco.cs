using System;
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
                    situacao = table.Column<int>(type: "integer", nullable: false),
                    cnpj = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    logradouro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cep = table.Column<int>(type: "integer", nullable: false),
                    nomerazaosocial = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    telefone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedor", x => x.fornecedorid);
                });

            migrationBuilder.CreateTable(
                name: "secretaria",
                columns: table => new
                {
                    secretariaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    situacao = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    logradouro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cep = table.Column<int>(type: "integer", nullable: false),
                    nomerazaosocial = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    telefone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_secretaria", x => x.secretariaid);
                });

            migrationBuilder.CreateTable(
                name: "tipoinstituicao",
                columns: table => new
                {
                    tipoinstituicaoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoinstituicao", x => x.tipoinstituicaoid);
                });

            migrationBuilder.CreateTable(
                name: "unidademedida",
                columns: table => new
                {
                    unidademedidaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descrição = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    abreviatura = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidademedida", x => x.unidademedidaid);
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
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    senha = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false),
                    matricula = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.usuarioid);
                });

            migrationBuilder.CreateTable(
                name: "instituicao",
                columns: table => new
                {
                    instituicaoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    situacao = table.Column<int>(type: "integer", nullable: false),
                    cnpj = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    logradouro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cep = table.Column<int>(type: "integer", nullable: false),
                    nomerazaosocial = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    telefone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tipoinstituicaoid = table.Column<int>(type: "integer", nullable: false),
                    secretariaid = table.Column<int>(type: "integer", nullable: false),
                    SecretariaModelId = table.Column<int>(type: "integer", nullable: true),
                    TipoInstituicaoModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instituicao", x => x.instituicaoid);
                    table.ForeignKey(
                        name: "FK_instituicao_secretaria_SecretariaModelId",
                        column: x => x.SecretariaModelId,
                        principalTable: "secretaria",
                        principalColumn: "secretariaid");
                    table.ForeignKey(
                        name: "FK_instituicao_secretaria_secretariaid",
                        column: x => x.secretariaid,
                        principalTable: "secretaria",
                        principalColumn: "secretariaid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_instituicao_tipoinstituicao_TipoInstituicaoModelId",
                        column: x => x.TipoInstituicaoModelId,
                        principalTable: "tipoinstituicao",
                        principalColumn: "tipoinstituicaoid");
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
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    solicitauc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    idunidademedida = table.Column<int>(type: "integer", nullable: false),
                    UnidadeMedidaModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipodespesa", x => x.tipodespesaid);
                    table.ForeignKey(
                        name: "FK_tipodespesa_unidademedida_UnidadeMedidaModelId",
                        column: x => x.UnidadeMedidaModelId,
                        principalTable: "unidademedida",
                        principalColumn: "unidademedidaid");
                    table.ForeignKey(
                        name: "FK_tipodespesa_unidademedida_idunidademedida",
                        column: x => x.idunidademedida,
                        principalTable: "unidademedida",
                        principalColumn: "unidademedidaid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unidadeconsumidora",
                columns: table => new
                {
                    unidadeconsumidoraid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    unidadeconsumidora = table.Column<int>(type: "integer", nullable: false),
                    fornecedorid = table.Column<int>(type: "integer", nullable: false),
                    instituicaoid = table.Column<int>(type: "integer", nullable: false),
                    FornecedorModelId = table.Column<int>(type: "integer", nullable: true),
                    InstituicaoModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidadeconsumidora", x => x.unidadeconsumidoraid);
                    table.ForeignKey(
                        name: "FK_unidadeconsumidora_fornecedor_FornecedorModelId",
                        column: x => x.FornecedorModelId,
                        principalTable: "fornecedor",
                        principalColumn: "fornecedorid");
                    table.ForeignKey(
                        name: "FK_unidadeconsumidora_fornecedor_fornecedorid",
                        column: x => x.fornecedorid,
                        principalTable: "fornecedor",
                        principalColumn: "fornecedorid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_unidadeconsumidora_instituicao_InstituicaoModelId",
                        column: x => x.InstituicaoModelId,
                        principalTable: "instituicao",
                        principalColumn: "instituicaoid");
                    table.ForeignKey(
                        name: "FK_unidadeconsumidora_instituicao_instituicaoid",
                        column: x => x.instituicaoid,
                        principalTable: "instituicao",
                        principalColumn: "instituicaoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orcamento",
                columns: table => new
                {
                    orcamentoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    anoorcamento = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    valororcamento = table.Column<double>(type: "double precision", maxLength: 50, nullable: false),
                    tipodespesaid = table.Column<int>(type: "integer", nullable: false),
                    instituicaoid = table.Column<int>(type: "integer", nullable: false),
                    InstituicaoModelId = table.Column<int>(type: "integer", nullable: true),
                    TipoDespesaModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orcamento", x => x.orcamentoid);
                    table.ForeignKey(
                        name: "FK_orcamento_instituicao_InstituicaoModelId",
                        column: x => x.InstituicaoModelId,
                        principalTable: "instituicao",
                        principalColumn: "instituicaoid");
                    table.ForeignKey(
                        name: "FK_orcamento_instituicao_instituicaoid",
                        column: x => x.instituicaoid,
                        principalTable: "instituicao",
                        principalColumn: "instituicaoid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orcamento_tipodespesa_TipoDespesaModelId",
                        column: x => x.TipoDespesaModelId,
                        principalTable: "tipodespesa",
                        principalColumn: "tipodespesaid");
                    table.ForeignKey(
                        name: "FK_orcamento_tipodespesa_tipodespesaid",
                        column: x => x.tipodespesaid,
                        principalTable: "tipodespesa",
                        principalColumn: "tipodespesaid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    despesaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numerodocumento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    numerocontrole = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    anomesconsumo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    quantidadeconsumida = table.Column<double>(type: "numeric(18,2)", nullable: false),
                    datavencimento = table.Column<DateOnly>(type: "date", nullable: false),
                    valorprevisto = table.Column<double>(type: "numeric(18,2)", nullable: false),
                    datapagamento = table.Column<DateOnly>(type: "date", nullable: false),
                    valorpago = table.Column<double>(type: "numeric(18,2)", nullable: false),
                    anoemissao = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    semestreemissao = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    trimestreemissao = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    mesemissao = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false),
                    FornecedorId = table.Column<int>(type: "integer", nullable: true),
                    fornecedorid = table.Column<int>(type: "integer", nullable: false),
                    UnidadeConsumidoraId = table.Column<int>(type: "integer", nullable: true),
                    unidadeconsumidoraid = table.Column<int>(type: "integer", nullable: false),
                    InstituicaoId = table.Column<int>(type: "integer", nullable: true),
                    instituicaoid = table.Column<int>(type: "integer", nullable: false),
                    OrcamentoId = table.Column<int>(type: "integer", nullable: true),
                    orcamentoid = table.Column<int>(type: "integer", nullable: false),
                    TipoDespesaId = table.Column<int>(type: "integer", nullable: true),
                    tipodespesaid = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true),
                    usuarioid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.despesaid);
                    table.ForeignKey(
                        name: "FK_Despesa_fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "fornecedor",
                        principalColumn: "fornecedorid");
                    table.ForeignKey(
                        name: "FK_Despesa_instituicao_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "instituicao",
                        principalColumn: "instituicaoid");
                    table.ForeignKey(
                        name: "FK_Despesa_orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "orcamento",
                        principalColumn: "orcamentoid");
                    table.ForeignKey(
                        name: "FK_Despesa_tipodespesa_TipoDespesaId",
                        column: x => x.TipoDespesaId,
                        principalTable: "tipodespesa",
                        principalColumn: "tipodespesaid");
                    table.ForeignKey(
                        name: "FK_Despesa_unidadeconsumidora_UnidadeConsumidoraId",
                        column: x => x.UnidadeConsumidoraId,
                        principalTable: "unidadeconsumidora",
                        principalColumn: "unidadeconsumidoraid");
                    table.ForeignKey(
                        name: "FK_Despesa_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "usuarioid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_FornecedorId",
                table: "Despesa",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_InstituicaoId",
                table: "Despesa",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_OrcamentoId",
                table: "Despesa",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_TipoDespesaId",
                table: "Despesa",
                column: "TipoDespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_UnidadeConsumidoraId",
                table: "Despesa",
                column: "UnidadeConsumidoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_UsuarioId",
                table: "Despesa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_instituicao_secretariaid",
                table: "instituicao",
                column: "secretariaid");

            migrationBuilder.CreateIndex(
                name: "IX_instituicao_SecretariaModelId",
                table: "instituicao",
                column: "SecretariaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_instituicao_tipoinstituicaoid",
                table: "instituicao",
                column: "tipoinstituicaoid");

            migrationBuilder.CreateIndex(
                name: "IX_instituicao_TipoInstituicaoModelId",
                table: "instituicao",
                column: "TipoInstituicaoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_orcamento_instituicaoid",
                table: "orcamento",
                column: "instituicaoid");

            migrationBuilder.CreateIndex(
                name: "IX_orcamento_InstituicaoModelId",
                table: "orcamento",
                column: "InstituicaoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_orcamento_tipodespesaid",
                table: "orcamento",
                column: "tipodespesaid");

            migrationBuilder.CreateIndex(
                name: "IX_orcamento_TipoDespesaModelId",
                table: "orcamento",
                column: "TipoDespesaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_tipodespesa_idunidademedida",
                table: "tipodespesa",
                column: "idunidademedida");

            migrationBuilder.CreateIndex(
                name: "IX_tipodespesa_UnidadeMedidaModelId",
                table: "tipodespesa",
                column: "UnidadeMedidaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_unidadeconsumidora_fornecedorid",
                table: "unidadeconsumidora",
                column: "fornecedorid");

            migrationBuilder.CreateIndex(
                name: "IX_unidadeconsumidora_FornecedorModelId",
                table: "unidadeconsumidora",
                column: "FornecedorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_unidadeconsumidora_instituicaoid",
                table: "unidadeconsumidora",
                column: "instituicaoid");

            migrationBuilder.CreateIndex(
                name: "IX_unidadeconsumidora_InstituicaoModelId",
                table: "unidadeconsumidora",
                column: "InstituicaoModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesa");

            migrationBuilder.DropTable(
                name: "orcamento");

            migrationBuilder.DropTable(
                name: "unidadeconsumidora");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "tipodespesa");

            migrationBuilder.DropTable(
                name: "fornecedor");

            migrationBuilder.DropTable(
                name: "instituicao");

            migrationBuilder.DropTable(
                name: "unidademedida");

            migrationBuilder.DropTable(
                name: "secretaria");

            migrationBuilder.DropTable(
                name: "tipoinstituicao");
        }
    }
}
