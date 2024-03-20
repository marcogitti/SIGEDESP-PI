using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface ITipoUsuarioRepositorio
    {
        Task<List<TipoUsuarioModel>> BuscarTodosTipoUsuario();
        Task<TipoUsuarioModel> BuscarPorId(int id);
        Task<TipoUsuarioModel> Adicionar(TipoUsuarioModel tipoUsuario);
        Task<TipoUsuarioModel> Atualizar(TipoUsuarioModel tipoUsuario);
        Task<bool> Apagar(int id);
    }
}