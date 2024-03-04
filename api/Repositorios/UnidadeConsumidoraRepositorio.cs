using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;

namespace api.Repositorios
{
    public class UnidadeConsumidoraRepositorio : IUnidadeConsumidoraRepositorio

        private readonly SigedespDBContex _dbContext;
        public UnidadeConsumidoraRepositorio(SigedespDBContex sigedespDBContex)
        {
            _dbContext = sigedespDBContex;
        }

        public async Task<UnidadeConsumidoraModel> BuscarPorId(int id)
        {
            return await _dbContext.UnidadeConsumidora.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UnidadeConsumidoraModel>> BuscarTodosUnidadeConsumidora()
        {
            return await _dbContext.UnidadeConsumidora.ToListAsync();
        }

        public async Task<UnidadeConsumidoraModel> Adicionar(UnidadeConsumidoraModel unidadeConsumidora)
        {
            await _dbContext.UnidadeConsumidora.AddAsync(unidadeConsumidora);
            await _dbContext.SaveChangesAsync();

            return unidadeConsumidora;
        }

        public async Task<UnidadeConsumidoraModel> Atualizar(UnidadeConsumidoraModel unidadeConsumidora)
        {
            _dbContext.Entry(unidadeConsumidora).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return unidadeConsumidora;
        }

        public async Task<bool> Apagar(int id)
        {
            UnidadeConsumidoraModel unidadeConsumidoraPorId = await BuscarPorId(id);

            if (unidadeConsumidoraPorId == null)
            {
                throw new Exception($"Unidade Consumidora para o ID: {id} não foi encontrada no banco de dados");
            }

            _dbContext.UnidadeConsumidora.Remove(unidadeConsumidoraPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}