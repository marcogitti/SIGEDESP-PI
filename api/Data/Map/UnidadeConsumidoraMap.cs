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
            builder.Property(x => x.CodigoUC).IsRequired().HasMaxLength(10);
            builder.HasOne(x => x.Fornecedor).WithMany().HasForeignKey(x => x.IdFornecedor);
            builder.HasOne(x => x.Instituicao).WithMany().HasForeignKey(x => x.IdInstituicao);
        }
    }
}
