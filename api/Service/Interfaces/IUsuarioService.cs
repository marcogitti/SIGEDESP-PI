using api.Authentication;
using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> BuscarTodosUsuario();
        Task<UsuarioDTO> BuscarPorId(int id);
        Task<UsuarioDTO> BuscarPorEmail(string email);
        Task<UsuarioDTO> Login(Login login);
        Task Adicionar(UsuarioDTO UsuarioDTO);
        Task Atualizar(UsuarioDTO UsuarioDTO);
        Task Apagar(int id);

        // Adicione o método de validação de usuário:
        Task<UsuarioDTO> ValidarUsuario(string email, string senha);
    }
}