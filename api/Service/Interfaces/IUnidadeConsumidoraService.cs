using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface IUnidadeConsumidoraService
    {
        Task<IEnumerable<UnidadeConsumidoraDTO>> BuscarTodosUnidadeConsumidora();
        Task<UnidadeConsumidoraDTO> BuscarPorId(int id);
        Task Adicionar(UnidadeConsumidoraDTO UnidadeConsumidoraDTO);
        Task Atualizar(UnidadeConsumidoraDTO UnidadeConsumidoraDTO);
        Task Apagar(int id);
    }
}