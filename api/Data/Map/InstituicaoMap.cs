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

            // Propriedades
            builder.Property(x => x.CNPJ)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(x => x.Situacao)
                .IsRequired();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Logradouro)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.Bairro)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CEP)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(x => x.NomeRazaoSocial)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Cidade)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Estado)
                .IsRequired()
                .HasMaxLength(50);

            // Configuração das chaves estrangeiras
            builder.HasOne(d => d.TipoInstituicao)
                .WithMany()
                .HasForeignKey(d => d.IdTipoInstituicao)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Secretaria)
                .WithMany()
                .HasForeignKey(d => d.IdSecretaria)
                .OnDelete(DeleteBehavior.Cascade);

            // Inserções de teste
            builder.HasData(
                new InstituicaoModel
                {
                    Id = 1,
                    Situacao = Models.Enum.EnumSituacaoModel.ativo,
                    CNPJ = "12345678000195",
                    Nome = "Elza Pirro",
                    Logradouro = "Rua dos Educadores",
                    Numero = "100",
                    Bairro = "Centro",
                    CEP = "12345678",
                    NomeRazaoSocial = "Elza Pirro Vianna",
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
                    CNPJ = "98765432000190",
                    Nome = "ESF JACB",
                    Logradouro = "Avenida da Saúde",
                    Numero = "200",
                    Bairro = "Jardim América",
                    CEP = "87654321",
                    NomeRazaoSocial = "Dr Luis Ernesto Sandi Mori ",
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
