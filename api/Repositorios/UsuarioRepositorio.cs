using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;
using api.Models.Enum;

namespace api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        public UsuarioRepositorio(SigedespDBContex sigedespDBContex)
        {
            _dbContext = sigedespDBContex;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuario()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            if (!Enum.IsDefined(typeof(TipoUsuarioEnum), usuario.TipoUsuario))
            {
                throw new ArgumentException("Tipo de usuário inválido");
            }

            if (!Enum.IsDefined(typeof(SituacaoEnum), usuario.Situacao))
            {
                throw new ArgumentException("Tipo de situação inválida");
            }

            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario)
        {
            _dbContext.Entry(usuario).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel UsuarioPorId = await BuscarPorId(id);

            if (UsuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Usuario.Remove(UsuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
