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
            builder.Property(x => x.Situacao).IsRequired();
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

            // Relacionamentos
            builder.HasOne(x => x.tipoInstituicao)
                   .WithMany()
                   .HasForeignKey(x => x.IdTipoInstituicao);

            builder.HasOne(x => x.Secretaria)
                   .WithMany()
                   .HasForeignKey(x => x.IdSecretaria);

            // Inserções de teste
            builder.HasData(
                new InstituicaoModel
                {
                    Id = 1,
                    Situacao = Models.Enum.EnumSituacaoModel.ativo,
                    Cnpj = "12345678000195",
                    Nome = "Elza Pirro",
                    Logradouro = "Rua dos Educadores",
                    Numero = "100",
                    Bairro = "Centro",
                    Cep = "12345678",
                    nomeRazaoSocial = "Elza Pirro Vianna",
                    Telefone = "11987654321",
                    Email = "contato@escolaelzapirro@gamil.com",
                    Cidade = "Jales",
                    Estado = "São Paulo",
                    IdTipoInstituicao = 4, // Supondo que 1 seja um Tipo de Instituição existente
                    IdSecretaria = 2 // Supondo que 1 seja uma Secretaria existente
                },
                new InstituicaoModel
                {
                    Id = 2,
                    Situacao = Models.Enum.EnumSituacaoModel.inativo,
                    Cnpj = "98765432000190",
                    Nome = "ESF JACB",
                    Logradouro = "Avenida da Saúde",
                    Numero = "200",
                    Bairro = "Jardim América",
                    Cep = "87654321",
                    nomeRazaoSocial = "Dr Luis Ernesto Sandi Mori ",
                    Telefone = "21987654321",
                    Email = "contato@centrosaude.sp.gov.br",
                    Cidade = "Jales",
                    Estado = "São Paulo",
                    IdTipoInstituicao = 5, // Supondo que 2 seja outro Tipo de Instituição existente
                    IdSecretaria = 1 // Supondo que 2 seja outra Secretaria existente
                }
            );
        }
    }
}
