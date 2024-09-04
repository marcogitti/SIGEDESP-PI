using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface IDespesaService
    {
        Task<IEnumerable<DespesaDTO>> BuscarTodosDespesa();
        Task<DespesaDTO> BuscarPorId(int id);
        Task Adicionar(DespesaDTO DespesaDTO);
        Task Atualizar(DespesaDTO DespesaDTO);
        Task Apagar(int id);
    }
}