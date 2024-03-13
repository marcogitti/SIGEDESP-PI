using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class UnidadeConsumidoraMap : IEntityTypeConfiguration<UnidadeConsumidoraModel>
    {
        public void Configure(EntityTypeBuilder<UnidadeConsumidoraModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.codigoUC).IsRequired();

        }
    }
}
