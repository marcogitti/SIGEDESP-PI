using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;

namespace api.Repositorios
{
    public class TipoUsuarioRepositorio : ITipoUsuarioRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        public TipoUsuarioRepositorio(SigedespDBContex sigedespDBContex)
        {
            _dbContext = sigedespDBContex;
        }

        public async Task<TipoUsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.TipoUsuario.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TipoUsuarioModel>> BuscarTodosTipoUsuario()
        {
            return await _dbContext.TipoUsuario.ToListAsync();
        }

        public async Task<TipoUsuarioModel> Adicionar(TipoUsuarioModel tipoUsuario)
        {
            await _dbContext.TipoUsuario.AddAsync(tipoUsuario);
            await _dbContext.SaveChangesAsync();

            return tipoUsuario;
        }

        public async Task<TipoUsuarioModel> Atualizar(TipoUsuarioModel tipoUsuario)
        {
            _dbContext.Entry(tipoUsuario).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return tipoUsuario;
        }

        public async Task<bool> Apagar(int id)
        {
            TipoUsuarioModel tipoUsuarioPorId = await BuscarPorId(id);

            if (tipoUsuarioPorId == null)
            {
                throw new Exception($"Tipo Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.TipoUsuario.Remove(tipoUsuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
