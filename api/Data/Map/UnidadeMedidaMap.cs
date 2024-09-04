using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class UnidadeMedidaMap : IEntityTypeConfiguration<UnidadeMedidaModel>
    {
        public void Configure(EntityTypeBuilder<UnidadeMedidaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Abreviatura).IsRequired().HasMaxLength(10);

        }
    }
}