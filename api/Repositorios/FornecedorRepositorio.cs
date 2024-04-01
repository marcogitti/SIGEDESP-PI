using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;

namespace api.Repositorios
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        public FornecedorRepositorio(SigedespDBContex sigedespDBContex)
        {
            _dbContext = sigedespDBContex;
        }

        public async Task<FornecedorModel> BuscarPorId(int id)
        {
            return await _dbContext.Fornecedor.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<FornecedorModel>> BuscarTodosFornecedor()
        {
            return await _dbContext.Fornecedor.ToListAsync();
        }

        public async Task<FornecedorModel> Adicionar(FornecedorModel fornecedor)
        {
            await _dbContext.Fornecedor.AddAsync(fornecedor);
            await _dbContext.SaveChangesAsync();

            return fornecedor;
        }

        public async Task<FornecedorModel> Atualizar(FornecedorModel fornecedor)
        {
            _dbContext.Entry(fornecedor).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<bool> Apagar(int id)
        {
            FornecedorModel fornecedorPorId = await BuscarPorId(id);

            if (fornecedorPorId == null)
            {
                throw new Exception($"Fornecedor para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Fornecedor.Remove(fornecedorPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
