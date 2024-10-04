using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class FornecedorMap : IEntityTypeConfiguration<FornecedorModel>
    {
        public void Configure(EntityTypeBuilder<FornecedorModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeFantasia).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Situacao).IsRequired();
            builder.Property(x => x.Cnpj).IsRequired().HasMaxLength(14);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cep).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(25);

            // Inserções de teste
            builder.HasData(
                new FornecedorModel
                {
                    Id = 1,
                    NomeFantasia = "Sabesp",
                    Situacao = Models.Enum.EnumSituacaoModel.ativo,
                    Cnpj = "12345678000195",
                    Nome = "Cia de Saneamento Básico do Estado de São Paulo",
                    Logradouro = "Rua das Inovações",
                    Numero = "123",
                    Bairro = "Centro",
                    Cep = "12345678",
                    Telefone = "17987654321",
                    Email = "contato@sabesp.com",
                    Cidade = "Jales",
                    Estado = "São Paulo"
                },
                new FornecedorModel
                {
                    Id = 2,
                    NomeFantasia = "Elektro",
                    Situacao = Models.Enum.EnumSituacaoModel.ativo,
                    Cnpj = "98765432000190",
                    Nome = "Neoenergia Elektro",
                    Logradouro = "Avenida Brasil",
                    Numero = "456",
                    Bairro = "Jardim América",
                    Cep = "87654321",
                    Telefone = "17987654321",
                    Email = "contatos@elektro.com",
                    Cidade = "Jales",
                    Estado = "São Paulo"
                }
            );
        }
    }
}
