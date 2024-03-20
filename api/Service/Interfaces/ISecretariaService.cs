using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface ISecretariaService
    {
        Task<IEnumerable<SecretariaDTO>> BuscarTodosSecretaria();
        Task<SecretariaDTO> BuscarPorId(int id);
        Task Adicionar(SecretariaDTO SecretariaDTO);
        Task Atualizar(SecretariaDTO SecretariaDTO);
        Task Apagar(int id);
    }
}