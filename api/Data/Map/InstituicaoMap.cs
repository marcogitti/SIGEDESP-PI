using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class InstituicaoMap : IEntityTypeConfiguration<InstituicaoModel>
    {
        public void Configure(EntityTypeBuilder<InstituicaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Situacao).IsRequired().HasMaxLength(50);
            builder.HasOne(x => x.tipoInstituicao).WithMany().HasForeignKey(x => x.IdTipoInstituicao);
            builder.HasOne(x => x.Secretaria).WithMany().HasForeignKey(x => x.IdSecretaria);
        }
    }
}