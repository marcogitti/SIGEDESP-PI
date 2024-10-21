using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class DespesaMap : IEntityTypeConfiguration<DespesaModel>
    {
        public void Configure(EntityTypeBuilder<DespesaModel> builder)
        {
            builder.HasKey(x => x.Id);

            // Propriedades
            builder.Property(x => x.NumeroDocumento)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Situacao)
                .IsRequired();

            builder.Property(x => x.NumeroControle)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.AnoMesConsumo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.QuantidadeConsumida)
                .IsRequired();

            builder.Property(x => x.DataVencimento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.ValorPrevisto)
                .IsRequired();

            builder.Property(x => x.DataPagamento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.ValorPago)
                .IsRequired();

            builder.Property(x => x.AnoEmissao)
                .IsRequired();

            builder.Property(x => x.SemestreEmissao)
                .IsRequired();

            builder.Property(x => x.TrimestreEmissao)
                .IsRequired();

            builder.Property(x => x.MesEmissao)
                .IsRequired();

            // Configuração das chaves estrangeiras
            builder.HasOne(d => d.Usuario)
                .WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Fornecedor)
                .WithMany()
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.UnidadeConsumidora)
                .WithMany()
                .HasForeignKey(d => d.IdUnidadeConsumidora)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Instituicao)
                .WithMany()
                .HasForeignKey(d => d.IdInstituicao)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Orcamento)
                .WithMany()
                .HasForeignKey(d => d.IdOrcamento)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.TipoDespesa)
                .WithMany()
                .HasForeignKey(d => d.IdTipoDespesa)
                .OnDelete(DeleteBehavior.Cascade);

            // Inserções de teste
            builder.HasData(
                new DespesaModel
                {
                    Id = 1,
                    NumeroDocumento = "DOC001",
                    Situacao = Models.Enum.EnumSituacaoModel.ativo,
                    NumeroControle = "NC001",
                    AnoMesConsumo = "202401",
                    QuantidadeConsumida = 100.5,
                    DataVencimento = DateOnly.FromDateTime(new DateTime(2024, 01, 31)), // Ajuste para DateOnly
                    ValorPrevisto = 1500.00,
                    DataPagamento = DateOnly.FromDateTime(new DateTime(2024, 02, 05)), // Ajuste para DateOnly
                    ValorPago = 1400.00,
                    AnoEmissao = 2024,
                    SemestreEmissao = 1,
                    TrimestreEmissao = 1,
                    MesEmissao = 1,
                    IdUsuario = 1,
                    IdFornecedor = 1,
                    IdUnidadeConsumidora = 1,
                    IdInstituicao = 1,
                    IdOrcamento = 1,
                    IdTipoDespesa = 1
                },
                new DespesaModel
                {
                    Id = 2,
                    NumeroDocumento = "DOC002",
                    Situacao = Models.Enum.EnumSituacaoModel.ativo,
                    NumeroControle = "NC002",
                    AnoMesConsumo = "202401",
                    QuantidadeConsumida = 200.0,
                    DataVencimento = DateOnly.FromDateTime(new DateTime(2024, 02, 28)), // Ajuste para DateOnly
                    ValorPrevisto = 3000.00,
                    DataPagamento = DateOnly.FromDateTime(new DateTime(2024, 03, 05)), // Ajuste para DateOnly
                    ValorPago = 2900.00,
                    AnoEmissao = 2024,
                    SemestreEmissao = 1,
                    TrimestreEmissao = 1,
                    MesEmissao = 2,
                    IdUsuario = 2,
                    IdFornecedor = 2,
                    IdUnidadeConsumidora = 2,
                    IdInstituicao = 2,
                    IdOrcamento = 2,
                    IdTipoDespesa = 2
                }
            );
        }
    }
}
