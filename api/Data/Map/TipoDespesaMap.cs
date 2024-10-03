using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class TipoDespesaMap : IEntityTypeConfiguration<TipoDespesaModel>
    {
        public void Configure(EntityTypeBuilder<TipoDespesaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SolicitaUC).IsRequired();

            // Definindo a chave estrangeira para UnidadeMedida
            builder.HasOne(x => x.UnidadeMedida)
                   .WithMany()
                   .HasForeignKey(x => x.IdUnidadeMedida);

            // Inserções de teste
            builder.HasData(
                new TipoDespesaModel
                {
                    Id = 1,
                    Descricao = "Água",
                    SolicitaUC = Models.Enum.EnumSolicitaUCModel.sim,
                    IdUnidadeMedida = 2 // Assumindo que 1 é a ID de uma unidade de medida existente
                },
                new TipoDespesaModel
                {
                    Id = 2,
                    Descricao = "Energia",
                    SolicitaUC = Models.Enum.EnumSolicitaUCModel.nao,
                    IdUnidadeMedida = 6 // Assumindo que 2 é a ID de outra unidade de medida existente
                }
            );
        }
    }
}
