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
            builder.Property(x => x.NumeroDocumento).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Situacao).IsRequired();
            builder.Property(x => x.NumeroControle).IsRequired().HasMaxLength(50);
            builder.Property(x => x.AnoMesConsumo).IsRequired().HasMaxLength(50);
            builder.Property(x => x.QuantidadeConsumida).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.DataVencimento).IsRequired().HasColumnType("date");
            builder.Property(x => x.ValorPrevisto).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.DataPagamento).IsRequired().HasColumnType("date");
            builder.Property(x => x.ValorPago).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.AnoEmissao).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SemestreEmissao).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TrimestreEmissao).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MesEmissao).IsRequired().HasMaxLength(50);

        }
    }
}