using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "auditoria",
                columns: table => new
                {
                    auditoriaid = table.Column<Guid>(type: "uuid", nullable: false),
                    data = table.Column<string>(type: "text", nullable: false),
                    hora = table.Column<string>(type: "text", nullable: false),
                    operacao = table.Column<string>(type: "text", nullable: false),
                    nomeentidade = table.Column<string>(type: "text", nullable: false),
                    valoresantigos = table.Column<string>(type: "text", nullable: true),
                    novosvalores = table.Column<string>(type: "text", nullable: true),
                    idusuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auditoria", x => x.auditoriaid);
                });

            migrationBuilder.CreateTable(
                name: "fornecedor",
                columns: table => new
                {
                    fornecedorid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomefantasia = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    situcao = table.Column<int>(type: "integer", nullable: false),
                    cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    logradouro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    numero = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    telefone = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cidade = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    estado = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
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
                    situcao = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    logradouro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    numero = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    nomerazaosocial = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cidade = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    estado = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
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
                    descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
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
                    descrição = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    abreviatura = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
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
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    rg = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    logradouro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    numero = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    cidade = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    estado = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    situcao = table.Column<int>(type: "integer", nullable: false),
                    matricula = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    tipousuario = table.Column<int>(type: "integer", nullable: false)
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
                    situcao = table.Column<int>(type: "integer", nullable: false),
                    cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    logradouro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    numero = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    nomerazaosocial = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
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
                    solicitauc = table.Column<int>(type: "integer", nullable: false),
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
                    unidadeconsumidora = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
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
                    anoorcamento = table.Column<int>(type: "integer", nullable: false),
                    valororcamento = table.Column<double>(type: "double precision", nullable: false),
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
                name: "despesa",
                columns: table => new
                {
                    despesaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numerodocumento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    numerocontrole = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    anomesconsumo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    quantidadeconsumida = table.Column<double>(type: "double precision", nullable: false),
                    datavencimento = table.Column<DateOnly>(type: "date", nullable: false),
                    valorprevisto = table.Column<double>(type: "double precision", nullable: false),
                    datapagamento = table.Column<DateOnly>(type: "date", nullable: false),
                    valorpago = table.Column<double>(type: "double precision", nullable: false),
                    anoemissao = table.Column<int>(type: "integer", nullable: false),
                    semestreemissao = table.Column<int>(type: "integer", nullable: false),
                    trimestreemissao = table.Column<int>(type: "integer", nullable: false),
                    mesemissao = table.Column<int>(type: "integer", nullable: false),
                    situcao = table.Column<int>(type: "integer", nullable: false),
                    fornecedorid = table.Column<int>(type: "integer", nullable: false),
                    unidadeconsumidoraid = table.Column<int>(type: "integer", nullable: false),
                    instituicaoid = table.Column<int>(type: "integer", nullable: false),
                    orcamentoid = table.Column<int>(type: "integer", nullable: false),
                    tipodespesaid = table.Column<int>(type: "integer", nullable: false),
                    statusdespesa = table.Column<int>(type: "integer", nullable: false),
                    usuarioid = table.Column<int>(type: "integer", nullable: false),
                    FornecedorModelId = table.Column<int>(type: "integer", nullable: true),
                    InstituicaoModelId = table.Column<int>(type: "integer", nullable: true),
                    OrcamentoModelId = table.Column<int>(type: "integer", nullable: true),
                    TipoDespesaModelId = table.Column<int>(type: "integer", nullable: true),
                    UsuarioModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_despesa", x => x.despesaid);
                    table.ForeignKey(
                        name: "FK_despesa_fornecedor_FornecedorModelId",
                        column: x => x.FornecedorModelId,
                        principalTable: "fornecedor",
                        principalColumn: "fornecedorid");
                    table.ForeignKey(
                        name: "FK_despesa_fornecedor_fornecedorid",
                        column: x => x.fornecedorid,
                        principalTable: "fornecedor",
                        principalColumn: "fornecedorid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_despesa_instituicao_InstituicaoModelId",
                        column: x => x.InstituicaoModelId,
                        principalTable: "instituicao",
                        principalColumn: "instituicaoid");
                    table.ForeignKey(
                        name: "FK_despesa_instituicao_instituicaoid",
                        column: x => x.instituicaoid,
                        principalTable: "instituicao",
                        principalColumn: "instituicaoid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_despesa_orcamento_OrcamentoModelId",
                        column: x => x.OrcamentoModelId,
                        principalTable: "orcamento",
                        principalColumn: "orcamentoid");
                    table.ForeignKey(
                        name: "FK_despesa_orcamento_orcamentoid",
                        column: x => x.orcamentoid,
                        principalTable: "orcamento",
                        principalColumn: "orcamentoid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_despesa_tipodespesa_TipoDespesaModelId",
                        column: x => x.TipoDespesaModelId,
                        principalTable: "tipodespesa",
                        principalColumn: "tipodespesaid");
                    table.ForeignKey(
                        name: "FK_despesa_tipodespesa_tipodespesaid",
                        column: x => x.tipodespesaid,
                        principalTable: "tipodespesa",
                        principalColumn: "tipodespesaid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_despesa_unidadeconsumidora_unidadeconsumidoraid",
                        column: x => x.unidadeconsumidoraid,
                        principalTable: "unidadeconsumidora",
                        principalColumn: "unidadeconsumidoraid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_despesa_usuario_UsuarioModelId",
                        column: x => x.UsuarioModelId,
                        principalTable: "usuario",
                        principalColumn: "usuarioid");
                    table.ForeignKey(
                        name: "FK_despesa_usuario_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "usuario",
                        principalColumn: "usuarioid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "fornecedor",
                columns: new[] { "fornecedorid", "bairro", "cep", "cnpj", "cidade", "email", "estado", "logradouro", "nome", "nomefantasia", "numero", "situcao", "telefone" },
                values: new object[,]
                {
                    { 1, "Centro", "12345678", "12345678000195", "Jales", "contato@sabesp.com", "São Paulo", "Rua das Inovações", "Cia de Saneamento Básico do Estado de São Paulo", "Sabesp", "123", 1, "17987654321" },
                    { 2, "Jardim América", "87654321", "98765432000190", "Jales", "contatos@elektro.com", "São Paulo", "Avenida Brasil", "Neoenergia Elektro", "Elektro", "456", 1, "17987654321" }
                });

            migrationBuilder.InsertData(
                table: "secretaria",
                columns: new[] { "secretariaid", "bairro", "cep", "cnpj", "cidade", "descricao", "email", "estado", "logradouro", "nome", "nomerazaosocial", "numero", "situcao", "telefone" },
                values: new object[,]
                {
                    { 1, "Centro", "12345678", "12345678000195", "Jales", "Secretaria de Saúde", "saude@prefeitura.com", "São Paulo", "Rua Central", "Sec. Saúde", "Prefeitura Municipal", "100", 1, "11987654321" },
                    { 2, "Jardim Paulista", "87654321", "98765432000190", "Jales", "Secretaria de Educação", "educacao@prefeitura.com", "São Paulo", "Avenida da Cultura", "Sec. Educação", "Prefeitura Municipal", "200", 1, "21987654321" },
                    { 3, "Vila Nova", "65432187", "23456789000188", "Jales", "Secretaria de Obras", "obras@prefeitura.com", "São Paulo", "Rua das Construções", "Sec. Obras", "Prefeitura Municipal", "300", 0, "31987654321" }
                });

            migrationBuilder.InsertData(
                table: "tipoinstituicao",
                columns: new[] { "tipoinstituicaoid", "descricao" },
                values: new object[,]
                {
                    { 1, "Universidade" },
                    { 2, "Faculdade" },
                    { 3, "Escola Técnica" },
                    { 4, "Escola" },
                    { 5, "ESF" }
                });

            migrationBuilder.InsertData(
                table: "unidademedida",
                columns: new[] { "unidademedidaid", "abreviatura", "descrição" },
                values: new object[,]
                {
                    { 1, "kg", "Quilograma" },
                    { 2, "L", "Litro" },
                    { 3, "m", "Metro" },
                    { 4, "cm", "Centímetro" },
                    { 5, "mm", "Milímetro" },
                    { 6, "kW", "Kilowatt" }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "usuarioid", "bairro", "cep", "cpf", "cidade", "email", "estado", "logradouro", "matricula", "nome", "numero", "rg", "senha", "situcao", "tipousuario" },
                values: new object[,]
                {
                    { 1, "Centro", "12345678", "12345678901", "Jales", "joao.silva@gmail.com", "São Paulo", "Rua A", "20240001", "João Silva", "10", "123456789", "senha123", 1, 0 },
                    { 2, "Centro", "87654321", "98765432100", "Jales", "maria.souza@example.com", "São Paulo", "Avenida B", "20240002", "Maria Souza", "20", "987654321", "senha456", 0, 1 },
                    { 3, "Nova York", "87654330", "98785432100", "Jales", "rafael.andrade@gmail.com", "São Paulo", "Avenida C", "20240003", "Rafael Andrade", "30", "787654321", "senha789", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "instituicao",
                columns: new[] { "instituicaoid", "bairro", "cep", "cnpj", "cidade", "email", "estado", "secretariaid", "tipoinstituicaoid", "logradouro", "nome", "nomerazaosocial", "numero", "SecretariaModelId", "situcao", "telefone", "TipoInstituicaoModelId" },
                values: new object[,]
                {
                    { 1, "Centro", "12345678", "12345678000195", "Jales", "contato@escolaelzapirro@gamil.com", "São Paulo", 2, 4, "Rua dos Educadores", "Elza Pirro", "Elza Pirro Vianna", "100", null, 1, "11987654321", null },
                    { 2, "Jardim América", "87654321", "98765432000190", "Jales", "contato@centrosaude.sp.gov.br", "São Paulo", 1, 5, "Avenida da Saúde", "ESF JACB", "Dr Luis Ernesto Sandi Mori ", "200", null, 0, "21987654321", null }
                });

            migrationBuilder.InsertData(
                table: "tipodespesa",
                columns: new[] { "tipodespesaid", "descricao", "idunidademedida", "solicitauc", "UnidadeMedidaModelId" },
                values: new object[,]
                {
                    { 1, "Água", 2, 1, null },
                    { 2, "Energia", 6, 0, null }
                });

            migrationBuilder.InsertData(
                table: "orcamento",
                columns: new[] { "orcamentoid", "anoorcamento", "instituicaoid", "tipodespesaid", "InstituicaoModelId", "TipoDespesaModelId", "valororcamento" },
                values: new object[,]
                {
                    { 1, 2024, 1, 1, null, null, 5000000.0 },
                    { 2, 2024, 2, 2, null, null, 1200000.0 }
                });

            migrationBuilder.InsertData(
                table: "unidadeconsumidora",
                columns: new[] { "unidadeconsumidoraid", "unidadeconsumidora", "FornecedorModelId", "fornecedorid", "instituicaoid", "InstituicaoModelId" },
                values: new object[,]
                {
                    { 1, "00001", null, 1, 1, null },
                    { 2, "00002", null, 2, 2, null }
                });

            migrationBuilder.InsertData(
                table: "despesa",
                columns: new[] { "despesaid", "anoemissao", "anomesconsumo", "datapagamento", "datavencimento", "FornecedorModelId", "fornecedorid", "instituicaoid", "orcamentoid", "tipodespesaid", "unidadeconsumidoraid", "usuarioid", "InstituicaoModelId", "mesemissao", "numerocontrole", "numerodocumento", "OrcamentoModelId", "quantidadeconsumida", "semestreemissao", "situcao", "statusdespesa", "TipoDespesaModelId", "trimestreemissao", "UsuarioModelId", "valorpago", "valorprevisto" },
                values: new object[,]
                {
                    { 1, 2024, "202401", new DateOnly(2024, 2, 5), new DateOnly(2024, 1, 31), null, 1, 1, 1, 1, 1, 1, null, 1, "NC001", "DOC001", null, 100.5, 1, 1, 0, null, 1, null, 1400.0, 1500.0 },
                    { 2, 2024, "202401", new DateOnly(2024, 3, 5), new DateOnly(2024, 2, 28), null, 2, 2, 2, 2, 2, 2, null, 2, "NC002", "DOC002", null, 200.0, 1, 1, 0, null, 1, null, 2900.0, 3000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_despesa_fornecedorid",
                table: "despesa",
                column: "fornecedorid");

            migrationBuilder.CreateIndex(
                name: "IX_despesa_FornecedorModelId",
                table: "despesa",
                column: "FornecedorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_despesa_instituicaoid",
                table: "despesa",
                column: "instituicaoid");

            migrationBuilder.CreateIndex(
                name: "IX_despesa_InstituicaoModelId",
                table: "despesa",
                column: "InstituicaoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_despesa_orcamentoid",
                table: "despesa",
                column: "orcamentoid");

            migrationBuilder.CreateIndex(
                name: "IX_despesa_OrcamentoModelId",
                table: "despesa",
                column: "OrcamentoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_despesa_tipodespesaid",
                table: "despesa",
                column: "tipodespesaid");

            migrationBuilder.CreateIndex(
                name: "IX_despesa_TipoDespesaModelId",
                table: "despesa",
                column: "TipoDespesaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_despesa_unidadeconsumidoraid",
                table: "despesa",
                column: "unidadeconsumidoraid");

            migrationBuilder.CreateIndex(
                name: "IX_despesa_usuarioid",
                table: "despesa",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_despesa_UsuarioModelId",
                table: "despesa",
                column: "UsuarioModelId");

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
                name: "auditoria");

            migrationBuilder.DropTable(
                name: "despesa");

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
