using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;

namespace api.Repositorios
{
    public class SecretariaRepositorio : ISecretariaRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        public SecretariaRepositorio(SigedespDBContex sigedespDBContex)
        {
            _dbContext = sigedespDBContex;
        }

        public async Task<SecretariaModel> BuscarPorId(int id)
        {
            return await _dbContext.Secretaria.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<SecretariaModel>> BuscarTodosSecretaria()
        {
            return await _dbContext.Secretaria.ToListAsync();
        }

        public async Task<SecretariaModel> Adicionar(SecretariaModel secretaria)
        {
            await _dbContext.Secretaria.AddAsync(secretaria);
            await _dbContext.SaveChangesAsync();

            return secretaria;
        }

        public async Task<SecretariaModel> Atualizar(SecretariaModel secretaria)
        {
            _dbContext.Entry(secretaria).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return secretaria;
        }

        public async Task<bool> Apagar(int id)
        {
            SecretariaModel secretariaPorId = await BuscarPorId(id);

            if (secretariaPorId == null)
            {
                throw new Exception($"Secretaria para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Secretaria.Remove(secretariaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
