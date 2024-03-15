using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;

namespace api.Repositorios
{
    public class UnidadeMedidaRepositorio : IUnidadeMedidaRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        public UnidadeMedidaRepositorio(SigedespDBContex sigedespDBContex)
        {
            _dbContext = sigedespDBContex;
        }

        public async Task<UnidadeMedidaModel> BuscarPorId(int id)
        {
            return await _dbContext.UnidadeMedida.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UnidadeMedidaModel>> BuscarTodosUnidadeMedida()
        {
            return await _dbContext.UnidadeMedida.ToListAsync();
        }

        public async Task<UnidadeMedidaModel> Adicionar(UnidadeMedidaModel unidadeMedida)
        {
            await _dbContext.UnidadeMedida.AddAsync(unidadeMedida);
            await _dbContext.SaveChangesAsync();

            return unidadeMedida;
        }

        public async Task<UnidadeMedidaModel> Atualizar(UnidadeMedidaModel unidadeMedida)
        {
            _dbContext.Entry(unidadeMedida).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return unidadeMedida;
        }

        public async Task<bool> Apagar(int id)
        {
            UnidadeMedidaModel unidadeMedidaPorId = await BuscarPorId(id);

            if (unidadeMedidaPorId == null)
            {
                throw new Exception($"Unidade de Medida para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.UnidadeMedida.Remove(unidadeMedidaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
