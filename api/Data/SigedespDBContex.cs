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
        public DbSet<UnidadeMedidaModel> UnidadeMedida { get; set; }
        public DbSet<UnidadeConsumidoraModel> UnidadeConsumidora { get; set; }
        public DbSet<SecretariaModel> Secretaria { get; set; }
        public DbSet<FornecedorModel> Fornecedor { get; set; }
        public DbSet<InstituicaoModel> Instituicao { get; set; }
        public DbSet<OrcamentoModel> Orcamento { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<DespesaModel> Despesa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoDespesaMap());
            modelBuilder.ApplyConfiguration(new TipoInstituicaoMap());
            modelBuilder.ApplyConfiguration(new UnidadeMedidaMap());
            modelBuilder.ApplyConfiguration(new UnidadeConsumidoraMap());
            modelBuilder.ApplyConfiguration(new SecretariaMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new InstituicaoMap());
            modelBuilder.ApplyConfiguration(new OrcamentoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new DespesaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
