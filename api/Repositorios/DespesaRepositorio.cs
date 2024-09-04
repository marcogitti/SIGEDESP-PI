using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;

namespace api.Repositorios
{
    public class DespesaRepositorio : IDespesaRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        public DespesaRepositorio(SigedespDBContex sigedespDBContex)
        {
            _dbContext = sigedespDBContex;
        }

        public async Task<DespesaModel> BuscarPorId(int id)
        {
            return await _dbContext.Despesa.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<DespesaModel>> BuscarTodosDespesa()
        {
            return await _dbContext.Despesa.ToListAsync();
        }

        public async Task<DespesaModel> Adicionar(DespesaModel despesa)
        {
            await _dbContext.Despesa.AddAsync(despesa);
            await _dbContext.SaveChangesAsync();

            return despesa;
        }

        public async Task<DespesaModel> Atualizar(DespesaModel despesa)
        {
            _dbContext.Entry(despesa).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return despesa;
        }

        public async Task<bool> Apagar(int id)
        {
            DespesaModel despesaPorId = await BuscarPorId(id);

            if (despesaPorId == null)
            {
                throw new Exception($"Despesa para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Despesa.Remove(despesaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
