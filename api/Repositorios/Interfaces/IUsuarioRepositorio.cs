using api.Authentication;
using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuario();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Login(Login login);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario);
        Task<bool> Apagar(int id);

        // Método para buscar usuário por e-mail
        Task<UsuarioModel> BuscarPorEmail(string email);
    }
}
