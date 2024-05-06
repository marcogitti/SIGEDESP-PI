using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> BuscarTodosUsuario();
        Task<UsuarioDTO> BuscarPorId(int id);
        Task Adicionar(UsuarioDTO UsuarioDTO);
        Task Atualizar(UsuarioDTO UsuarioDTO);
        Task Apagar(int id);
    }
}