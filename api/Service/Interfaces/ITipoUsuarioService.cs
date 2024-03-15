using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface ITipoUsuarioService
    {
        Task<IEnumerable<TipoUsuarioDTO>> BuscarTodosTipoUsuario();
        Task<TipoUsuarioDTO> BuscarPorId(int id);
        Task Adicionar(TipoUsuarioDTO TipoUsuarioDTO);
        Task Atualizar(TipoUsuarioDTO TipoUsuarioDTO);
        Task Apagar(int id);
    }
}