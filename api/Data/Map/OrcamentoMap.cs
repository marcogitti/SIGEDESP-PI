using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class OrcamentoMap : IEntityTypeConfiguration<OrcamentoModel>
    {
        public void Configure(EntityTypeBuilder<OrcamentoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AnoOrcamento).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ValorOrcamento).IsRequired().HasMaxLength(50);

        }
    }
}
