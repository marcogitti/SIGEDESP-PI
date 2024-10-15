using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class UnidadeConsumidoraMap : IEntityTypeConfiguration<UnidadeConsumidoraModel>
    {
        public void Configure(EntityTypeBuilder<UnidadeConsumidoraModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CodigoUC)
            .IsRequired()
            .HasMaxLength(50);

            // Configuração das chaves estrangeiras

            builder.HasOne(d => d.Fornecedor)
                .WithMany()
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Instituicao)
                .WithMany()
                .HasForeignKey(d => d.IdInstituicao)
                .OnDelete(DeleteBehavior.Cascade);

            // Inserções de teste
            builder.HasData(
                new UnidadeConsumidoraModel
                {
                    Id = 1,
                    CodigoUC = "00001",
                    IdFornecedor = 1, // Supondo que 1 é um fornecedor já existente
                    IdInstituicao = 1  // Supondo que 1 é uma instituição já existente
                },
                new UnidadeConsumidoraModel
                {
                    Id = 2,
                    CodigoUC = "00002",
                    IdFornecedor = 2, // Supondo que 2 é outro fornecedor existente
                    IdInstituicao = 2  // Supondo que 2 é outra instituição já existente
                }
            );
        }
    }
}
