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
            builder.Property(x => x.Situacao).IsRequired();
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Cnpj).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Numero);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Rua).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Cep);
            builder.Property(x => x.nomeRazaoSocial).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(50);

        }
    }
}