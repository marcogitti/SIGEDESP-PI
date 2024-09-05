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
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cnpj).IsRequired().HasMaxLength(14);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cep).IsRequired().HasMaxLength(8);
            builder.Property(x => x.nomeRazaoSocial).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(25);

        }
    }
}