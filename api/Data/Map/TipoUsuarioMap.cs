using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class TipoUsuarioMap : IEntityTypeConfiguration<TipoUsuarioModel>
    {
        public void Configure(EntityTypeBuilder<TipoUsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PermiteLogin).IsRequired().HasMaxLength(50);

        }
    }
}