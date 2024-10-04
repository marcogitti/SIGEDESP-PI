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

            // Inserções de teste
            builder.HasData(
                new SecretariaModel
                {
                    Id = 1,
                    Situacao = Models.Enum.EnumSituacaoModel.ativo,
                    Descricao = "Secretaria de Saúde",
                    Cnpj = "12345678000195",
                    Nome = "Sec. Saúde",
                    Logradouro = "Rua Central",
                    Numero = "100",
                    Bairro = "Centro",
                    Cep = "12345678",
                    nomeRazaoSocial = "Prefeitura Municipal",
                    Telefone = "11987654321",
                    Email = "saude@prefeitura.com",
                    Cidade = "Jales",
                    Estado = "São Paulo"
                },
                new SecretariaModel
                {
                    Id = 2,
                    Situacao = Models.Enum.EnumSituacaoModel.ativo,
                    Descricao = "Secretaria de Educação",
                    Cnpj = "98765432000190",
                    Nome = "Sec. Educação",
                    Logradouro = "Avenida da Cultura",
                    Numero = "200",
                    Bairro = "Jardim Paulista",
                    Cep = "87654321",
                    nomeRazaoSocial = "Prefeitura Municipal",
                    Telefone = "21987654321",
                    Email = "educacao@prefeitura.com",
                    Cidade = "Jales",
                    Estado = "São Paulo"
                },
                new SecretariaModel
                {
                    Id = 3,
                    Situacao = Models.Enum.EnumSituacaoModel.inativo,
                    Descricao = "Secretaria de Obras",
                    Cnpj = "23456789000188",
                    Nome = "Sec. Obras",
                    Logradouro = "Rua das Construções",
                    Numero = "300",
                    Bairro = "Vila Nova",
                    Cep = "65432187",
                    nomeRazaoSocial = "Prefeitura Municipal",
                    Telefone = "31987654321",
                    Email = "obras@prefeitura.com",
                    Cidade = "Jales",
                    Estado = "São Paulo"
                }
            );
        }
    }
}
