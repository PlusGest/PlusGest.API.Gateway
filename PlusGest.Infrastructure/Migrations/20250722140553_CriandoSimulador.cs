using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlusGest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriandoSimulador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeUsuario",
                table: "Usuario",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuario",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Usuario",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ClienteObservacao",
                columns: table => new
                {
                    ClienteObservacaoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Obervacao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteObservacao", x => x.ClienteObservacaoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SimuladorCliente",
                columns: table => new
                {
                    SimuladorClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomeCompleto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimuladorCliente", x => x.SimuladorClienteId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SimuladorImovel",
                columns: table => new
                {
                    SimuladorImovelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BancoFinanceira = table.Column<int>(type: "int", nullable: false),
                    ValorImovel = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ValorEntrada = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ValorFinanciado = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TaxaJurosAnual = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    TaxaJurosMensal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    TotalParcelas = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    VencimentoDia = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    AmortizacaoMensal = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ValorParcelaInicial = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ValorParcelaFinal = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ValorTotalPago = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    JurosTotal = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimuladorImovel", x => x.SimuladorImovelId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SimuladorNegociacao",
                columns: table => new
                {
                    SimuladorNegociacaoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    TipoCenario = table.Column<int>(type: "int", nullable: false),
                    PercentualDesconto = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ValorDividaOriginal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorProposta = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PrazoQuitacaoDias = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    EconomiaGerada = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorParcelaReduzida = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TotalParcelas = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimuladorNegociacao", x => x.SimuladorNegociacaoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SimuladorPagamento",
                columns: table => new
                {
                    SimuladorPagamentoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FormaPagamento = table.Column<int>(type: "int", nullable: false),
                    Parcelas = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ValorTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorParcela = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TemJuros = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    PercentualJuros = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PercentualDesconto = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimuladorPagamento", x => x.SimuladorPagamentoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SimuladorVeiculo",
                columns: table => new
                {
                    SimuladorVeiculoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Veiculo = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BancoFinanceira = table.Column<int>(type: "int", nullable: false),
                    ValorVeiculo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorEntrada = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorParcela = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TotalParcelas = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    VencimentoDia = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ParcelasPagas = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ParcelasAtraso = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ValorFinanciado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TotalFinanciado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    JurosFinanciado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TaxaJuros = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ParcelasRestantes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ValorAberto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorAtraso = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorFinalBem = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimuladorVeiculo", x => x.SimuladorVeiculoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Simulador",
                columns: table => new
                {
                    SimuladorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SimuladorClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SimuladorVeiculoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SimuladorImovelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SimuladorNegociacaoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SimuladorPagamentoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataAtentimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataExpriracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DadosAnonimizados = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    Midia = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulador", x => x.SimuladorId);
                    table.ForeignKey(
                        name: "FK_Simulador_SimuladorCliente_SimuladorClienteId",
                        column: x => x.SimuladorClienteId,
                        principalTable: "SimuladorCliente",
                        principalColumn: "SimuladorClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Simulador_SimuladorImovel_SimuladorImovelId",
                        column: x => x.SimuladorImovelId,
                        principalTable: "SimuladorImovel",
                        principalColumn: "SimuladorImovelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Simulador_SimuladorNegociacao_SimuladorNegociacaoId",
                        column: x => x.SimuladorNegociacaoId,
                        principalTable: "SimuladorNegociacao",
                        principalColumn: "SimuladorNegociacaoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Simulador_SimuladorPagamento_SimuladorPagamentoId",
                        column: x => x.SimuladorPagamentoId,
                        principalTable: "SimuladorPagamento",
                        principalColumn: "SimuladorPagamentoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Simulador_SimuladorVeiculo_SimuladorVeiculoId",
                        column: x => x.SimuladorVeiculoId,
                        principalTable: "SimuladorVeiculo",
                        principalColumn: "SimuladorVeiculoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Simulador_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Usuarioid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SimuladorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClienteObservacaoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomeCompleto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rg = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Celular = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereço = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FotoUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_ClienteObservacao_ClienteObservacaoId",
                        column: x => x.ClienteObservacaoId,
                        principalTable: "ClienteObservacao",
                        principalColumn: "ClienteObservacaoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Simulador_SimuladorId",
                        column: x => x.SimuladorId,
                        principalTable: "Simulador",
                        principalColumn: "SimuladorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Usuario_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ClienteObservacaoId",
                table: "Cliente",
                column: "ClienteObservacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_SimuladorId",
                table: "Cliente",
                column: "SimuladorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Usuarioid",
                table: "Cliente",
                column: "Usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Simulador_SimuladorClienteId",
                table: "Simulador",
                column: "SimuladorClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Simulador_SimuladorImovelId",
                table: "Simulador",
                column: "SimuladorImovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Simulador_SimuladorNegociacaoId",
                table: "Simulador",
                column: "SimuladorNegociacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Simulador_SimuladorPagamentoId",
                table: "Simulador",
                column: "SimuladorPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Simulador_SimuladorVeiculoId",
                table: "Simulador",
                column: "SimuladorVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Simulador_UsuarioId",
                table: "Simulador",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ClienteObservacao");

            migrationBuilder.DropTable(
                name: "Simulador");

            migrationBuilder.DropTable(
                name: "SimuladorCliente");

            migrationBuilder.DropTable(
                name: "SimuladorImovel");

            migrationBuilder.DropTable(
                name: "SimuladorNegociacao");

            migrationBuilder.DropTable(
                name: "SimuladorPagamento");

            migrationBuilder.DropTable(
                name: "SimuladorVeiculo");

            migrationBuilder.AlterColumn<string>(
                name: "NomeUsuario",
                table: "Usuario",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuario",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Usuario",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
