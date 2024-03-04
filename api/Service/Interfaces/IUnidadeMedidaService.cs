using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface IUnidadeMedidaService
    {
        Task<IEnumerable<UnidadeMedidaDTO>> BuscarTodosUnidadeMedida();
        Task<UnidadeMedidaDTO> BuscarPorId(int id);
        Task Adicionar(UnidadeMedidaDTO UnidadeMedidaDTO);
        Task Atualizar(UnidadeMedidaDTO UnidadeMedidaDTO);
        Task Apagar(int id);
    }
}