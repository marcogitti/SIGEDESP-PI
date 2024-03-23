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
            builder.Property(x => x.NomeFantasia).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Situacao).IsRequired().HasMaxLength(50);

        }
    }
}