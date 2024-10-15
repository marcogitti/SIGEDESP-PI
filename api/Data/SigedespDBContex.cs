using api.Data.Map;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        public DbSet<AuditoriaModel> Auditoria { get; set; }


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

        public override int SaveChanges()
        {
            // 1. Capturar auditoria antes de salvar as mudanças (exclusões, adições, modificações)
            var auditoriasPostSave = CapturarDadosAuditoria(out var entidadesAdicionadas);

            // 2. Salvar as mudanças no banco de dados (inserções, atualizações e exclusões)
            var resultado = base.SaveChanges();

            // 3. Atualizar IDs nas auditorias para entidades adicionadas após SaveChanges
            AtualizarIdsAuditoriaParaEntidadesAdicionadas(auditoriasPostSave, entidadesAdicionadas);

            // 4. Salvar auditorias no banco de dados
            if (auditoriasPostSave.Any())
            {
                this.Auditoria.AddRange(auditoriasPostSave);
                base.SaveChanges(); // Persistir as auditorias no banco de dados
            }

            return resultado;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // 1. Capturar auditoria antes de salvar as mudanças (exclusões, adições, modificações)
            var auditoriasPostSave = CapturarDadosAuditoria(out var entidadesAdicionadas);

            // 2. Salvar as mudanças no banco de dados (inserções, atualizações e exclusões)
            var resultado = await base.SaveChangesAsync(cancellationToken);

            // 3. Atualizar IDs nas auditorias para entidades adicionadas após SaveChangesAsync
            AtualizarIdsAuditoriaParaEntidadesAdicionadas(auditoriasPostSave, entidadesAdicionadas);

            // 4. Salvar auditorias no banco de dados
            if (auditoriasPostSave.Any())
            {
                this.Auditoria.AddRange(auditoriasPostSave);
                await base.SaveChangesAsync(cancellationToken); // Persistir as auditorias no banco de dados
            }

            return resultado;
        }

        private List<AuditoriaModel> CapturarDadosAuditoria(out List<object> entidadesAdicionadas)
        {
            var auditorias = new List<AuditoriaModel>();
            entidadesAdicionadas = new List<object>();

            // Itera sobre as entradas do ChangeTracker para entidades que foram adicionadas, modificadas ou deletadas.
            var entradas = ChangeTracker.Entries()
                .Where(e => (e.State == EntityState.Deleted || e.State == EntityState.Added || e.State == EntityState.Modified)
                             && e.Entity.GetType() != typeof(AuditoriaModel))
                .Select(e => new
                {
                    Entidade = e.Entity,
                    NomeEntidade = e.Metadata.Name,
                    Operacao = e.State.ToString(),
                    ValoresAntigos = e.State != EntityState.Added ? e.OriginalValues.Properties.ToDictionary(p => p.Name, p => e.OriginalValues[p]) : null,
                    NovosValores = e.State != EntityState.Deleted ? e.CurrentValues.Properties.ToDictionary(p => p.Name, p => e.CurrentValues[p]) : null
                });

            foreach (var entrada in entradas)
            {
                var auditoria = new AuditoriaModel
                {
                    Operacao = TraduzirOperacao(entrada.Operacao),
                    NomeEntidade = ExtrairNomeEntidade(entrada.NomeEntidade),
                    ValoresAntigos = entrada.ValoresAntigos != null ? Newtonsoft.Json.JsonConvert.SerializeObject(entrada.ValoresAntigos) : null,
                    NovosValores = entrada.NovosValores != null ? Newtonsoft.Json.JsonConvert.SerializeObject(entrada.NovosValores) : null,
                    IdUsuario = PegarIdUsuario(entrada), // Obtém o ID do usuário com base na entrada
                };

                // Preenche data e hora para auditoria
                auditoria.ObterData();
                auditoria.ObterHora();

                // Se for uma entidade adicionada, substitui o valor do ID em NovosValores para 0
                if (entrada.Operacao == EntityState.Added.ToString())
                {
                    var tipoEntidade = entrada.Entidade.GetType();
                    var propriedadeId = tipoEntidade.GetProperties().FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Any());

                    if (propriedadeId != null && entrada.NovosValores != null)
                    {
                        // Modifica o valor do ID em NovosValores para 0
                        entrada.NovosValores[propriedadeId.Name] = 0;
                        auditoria.NovosValores = Newtonsoft.Json.JsonConvert.SerializeObject(entrada.NovosValores);
                    }

                    // Armazena a entidade adicionada para uso posterior
                    entidadesAdicionadas.Add(entrada.Entidade);
                }

                auditorias.Add(auditoria);
            }

            return auditorias;
        }

        private void AtualizarIdsAuditoriaParaEntidadesAdicionadas(List<AuditoriaModel> auditoriasPostSave, List<object> entidadesAdicionadas)
        {
            foreach (var entidade in entidadesAdicionadas)
            {
                var entry = this.Entry(entidade);
                if (entry != null)
                {
                    var idProperty = entry.Metadata.FindPrimaryKey().Properties[0]; // Obtém a propriedade de ID
                    var idValue = entry.Property(idProperty.Name).CurrentValue; // Obtém o valor do ID gerado

                    // Atualiza a auditoria com o ID correto para a entidade adicionada
                    var auditoriaCorrespondente = auditoriasPostSave.FirstOrDefault(a => a.NomeEntidade == ExtrairNomeEntidade(entry.Metadata.Name) && a.NovosValores.Contains($"\"{idProperty.Name}\":0"));
                    if (auditoriaCorrespondente != null)
                    {
                        auditoriaCorrespondente.NovosValores = auditoriaCorrespondente.NovosValores.Replace($"\"{idProperty.Name}\":0", $"\"{idProperty.Name}\":{idValue}");
                    }
                }
            }
        }

        private string TraduzirOperacao(string estado)
        {
            // Converte o estado da entidade (Added, Modified, Deleted) em uma string amigável
            switch (estado)
            {
                case nameof(EntityState.Added):
                    return "Adicionado";
                case nameof(EntityState.Modified):
                    return "Modificado";
                case nameof(EntityState.Deleted):
                    return "Excluído";
                default:
                    return "Desconhecido";
            }
        }

        private string ExtrairNomeEntidade(string nomeCompleto)
        {
            // Remove o namespace e "Model" do nome da entidade para obter um nome mais limpo
            var nomeSemNamespace = nomeCompleto.Split('.').LastOrDefault();
            return nomeSemNamespace?.Replace("Model", string.Empty);
        }

        private int PegarIdUsuario(dynamic entrada)
        {
            // Obtém o ID do usuário com base nos valores da entrada dependendo do estado da entidade
            if (entrada.Operacao == EntityState.Added.ToString())
            {
                if (entrada.NovosValores != null && entrada.NovosValores.ContainsKey("IdUsuario"))
                {
                    return (int)entrada.NovosValores["IdUsuario"];
                }
            }
            else if ((entrada.Operacao == EntityState.Modified.ToString() || entrada.Operacao == EntityState.Deleted.ToString()) && entrada.ValoresAntigos != null && entrada.ValoresAntigos.ContainsKey("IdUsuario"))
            {
                return (int)entrada.ValoresAntigos["IdUsuario"];
            }

            return 0; // Retorna 0 se não encontrar o IdUsuario
        }
    }
}
