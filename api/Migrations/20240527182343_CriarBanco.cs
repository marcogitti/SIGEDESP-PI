﻿using Microsoft.EntityFrameworkCore.Migrations;
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
                    situacao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
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
                    situacao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
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
                    abreviatura = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidademedida", x => x.unidademedidaid);
                });

            migrationBuilder.CreateTable(
                name: "instituicao",
                columns: table => new
                {
                    instituicaoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    situacao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
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
                    matricula = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tipousuarioid = table.Column<int>(type: "integer", nullable: false),
                    TipoUsuarioModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.usuarioid);
                    table.ForeignKey(
                        name: "FK_usuario_tipousuario_TipoUsuarioModelId",
                        column: x => x.TipoUsuarioModelId,
                        principalTable: "tipousuario",
                        principalColumn: "tipousuarioid");
                    table.ForeignKey(
                        name: "FK_usuario_tipousuario_tipousuarioid",
                        column: x => x.tipousuarioid,
                        principalTable: "tipousuario",
                        principalColumn: "tipousuarioid",
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

            migrationBuilder.CreateIndex(
                name: "IX_usuario_tipousuarioid",
                table: "usuario",
                column: "tipousuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_TipoUsuarioModelId",
                table: "usuario",
                column: "TipoUsuarioModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "tipousuario");

            migrationBuilder.DropTable(
                name: "unidademedida");

            migrationBuilder.DropTable(
                name: "secretaria");

            migrationBuilder.DropTable(
                name: "tipoinstituicao");
        }
    }
}
