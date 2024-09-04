using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class TipoInstituicaoMap : IEntityTypeConfiguration<TipoInstituicaoModel>
    {
        public void Configure(EntityTypeBuilder<TipoInstituicaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x  => x.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
