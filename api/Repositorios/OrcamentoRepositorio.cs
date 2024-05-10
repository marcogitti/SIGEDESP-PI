using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;

namespace api.Repositorios
{
    public class OrcamentoRepositorio : IOrcamentoRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        public OrcamentoRepositorio(SigedespDBContex sigedespDBContex)
        {
            _dbContext = sigedespDBContex;
        }

        public async Task<OrcamentoModel> BuscarPorId(int id)
        {
            return await _dbContext.Orcamento.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<OrcamentoModel>> BuscarTodosOrcamento()
        {
            return await _dbContext.Orcamento.ToListAsync();
        }

        public async Task<OrcamentoModel> Adicionar(OrcamentoModel Orcamento)
        {
            await _dbContext.Orcamento.AddAsync(Orcamento);
            await _dbContext.SaveChangesAsync();

            return Orcamento;
        }

        public async Task<OrcamentoModel> Atualizar(OrcamentoModel Orcamento)
        {
            _dbContext.Entry(Orcamento).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Orcamento;
        }

        public async Task<bool> Apagar(int id)
        {
            OrcamentoModel OrcamentoPorId = await BuscarPorId(id);

            if (OrcamentoPorId == null)
            {
                throw new Exception($"Orcamento para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Orcamento.Remove(OrcamentoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
