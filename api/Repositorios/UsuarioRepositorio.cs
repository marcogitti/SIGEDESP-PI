using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;
using api.Models.Enum;
using api.Authentication;

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
            var usuario = await _dbContext.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario != null)
            {
                usuario.Senha = string.Empty; // Limpa o atributo Senha
            }
            return usuario;
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuario()
        {
            var usuarios = await _dbContext.Usuario.ToListAsync();
            foreach (var usuario in usuarios)
            {
                usuario.Senha = string.Empty; // Limpa o atributo Senha
            }
            return usuarios;
        }

        public async Task<UsuarioModel> Login(Login login)
        {
            var usuario = await _dbContext.Usuario
                .Where(u => u.Email == login.Email && u.Senha == login.Senha)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (usuario != null)
            {
                usuario.Senha = string.Empty;
            }

            return usuario;
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            if (!Enum.IsDefined(typeof(TipoUsuarioEnum), usuario.TipoUsuario))
            {
                throw new ArgumentException("Tipo de usuário inválido");
            }

            if (!Enum.IsDefined(typeof(EnumSituacaoModel), usuario.Situacao))
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

        // Implementação do método BuscarPorEmail
        public async Task<UsuarioModel> BuscarPorEmail(string email)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
