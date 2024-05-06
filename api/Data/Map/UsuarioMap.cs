using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CpfCnpj).IsRequired().HasMaxLength(50);
            builder.Property(x => x.NomeRazaoSocial).IsRequired().HasMaxLength(50);
            builder.HasKey(x => x.RgLe);
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(50);
            builder.HasKey(x => x.Numero);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(50);
            builder.HasKey(x => x.CEP);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Rua).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Situacao).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Matricula).IsRequired().HasMaxLength(50);
        }
    }
}