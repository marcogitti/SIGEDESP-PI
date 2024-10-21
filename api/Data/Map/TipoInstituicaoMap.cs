using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class TipoInstituicaoMap : IEntityTypeConfiguration<TipoInstituicaoModel>
    {
        public void Configure(EntityTypeBuilder<TipoInstituicaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);

            // Inserções de teste
            builder.HasData(
                new TipoInstituicaoModel { Id = 1, Descricao = "Universidade" },
                new TipoInstituicaoModel { Id = 2, Descricao = "Faculdade" },
                new TipoInstituicaoModel { Id = 3, Descricao = "Escola Técnica" },
                new TipoInstituicaoModel { Id = 4, Descricao = "Escola" },
                new TipoInstituicaoModel { Id = 5, Descricao = "ESF" }
            );
        }
    }
}
