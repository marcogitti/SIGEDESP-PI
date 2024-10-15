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

            // Inserções de teste
            builder.HasData(
                new UnidadeMedidaModel { Id = 1, Descricao = "Quilograma", Abreviatura = "kg" },
                new UnidadeMedidaModel { Id = 2, Descricao = "Litro", Abreviatura = "L" },
                new UnidadeMedidaModel { Id = 3, Descricao = "Metro", Abreviatura = "m" },
                new UnidadeMedidaModel { Id = 4, Descricao = "Centímetro", Abreviatura = "cm" },
                new UnidadeMedidaModel { Id = 5, Descricao = "Milímetro", Abreviatura = "mm" },
                new UnidadeMedidaModel { Id = 6, Descricao = "Kilowatt", Abreviatura = "kW" }

            );
        }
    }
}
