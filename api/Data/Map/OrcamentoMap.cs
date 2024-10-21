using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class OrcamentoMap : IEntityTypeConfiguration<OrcamentoModel>
    {
        public void Configure(EntityTypeBuilder<OrcamentoModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AnoOrcamento)
                .IsRequired();

            builder.Property(x => x.ValorOrcamento)
                .IsRequired();

            // Definir as chaves estrangeiras para Instituicao e TipoDespesa
            builder.HasOne(d => d.Instituicao)
                .WithMany()
                .HasForeignKey(d => d.IdInstituicao)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.TipoDespesa)
                .WithMany()
                .HasForeignKey(d => d.IdTipoDespesa)
                .OnDelete(DeleteBehavior.Cascade);

            // Inserções de teste
            builder.HasData(
                new OrcamentoModel
                {
                    Id = 1,
                    AnoOrcamento = 2024,
                    ValorOrcamento = 5000000.00,
                    IdInstituicao = 1,  // Supondo que 1 seja uma instituição existente
                    IdTipoDespesa = 1   // Supondo que 1 seja um tipo de despesa existente
                },
                new OrcamentoModel
                {
                    Id = 2,
                    AnoOrcamento = 2024,
                    ValorOrcamento = 1200000.00,
                    IdInstituicao = 2,  // Supondo que 2 seja outra instituição existente
                    IdTipoDespesa = 2   // Supondo que 2 seja outro tipo de despesa existente
                }
            );
        }
    }
}
