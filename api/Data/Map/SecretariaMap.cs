using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class SecretariaMap : IEntityTypeConfiguration<SecretariaModel>
    {
        public void Configure(EntityTypeBuilder<SecretariaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Situacao).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);

        }
    }
}