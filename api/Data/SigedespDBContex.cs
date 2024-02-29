using api.Data.Map;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class SigedespDBContex : DbContext
    {
        public SigedespDBContex(DbContextOptions<SigedespDBContex> options) : base(options) 
        {
        }

        public DbSet<TipoDespesaModel> TipoDespesa { get; set; }
        public DbSet<TipoInstituicaoModel> TipoInstituicao { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoDespesaMap());
            modelBuilder.ApplyConfiguration(new TipoInstituicaoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
