using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface IUnidadeConsumidoraService
    {
        Task<IEnumerable<UnidadeConsumidoraDTO>> BuscarTodosUnidadeConsumidora();
        Task<UnidadeConsumidoraDTO> BuscarPorId(int id);
        Task Adicionar(UnidadeConsumidoraAdicionarAtualizarDTO unidadeconsumidoraDTO);
        Task Atualizar(UnidadeConsumidoraAdicionarAtualizarDTO unidadeconsumidoraDTO);
        Task Apagar(int id);
    }
}