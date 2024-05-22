using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class TipoDespesaMap : IEntityTypeConfiguration<TipoDespesaModel>
    {
        public void Configure(EntityTypeBuilder<TipoDespesaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x  => x.TipoDespesa).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SolicitaUC).IsRequired().HasMaxLength(50);
            builder.HasOne(x => x.UnidadeMedida).WithMany().HasForeignKey(x => x.IdUnidadeMedida);

        }
    }
}
