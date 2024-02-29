using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface ITipoDespesaService
    {
        Task<IEnumerable<TipoDespesaDTO>> BuscarTodosTipoDespesa();
        Task<TipoDespesaDTO> BuscarPorId(int id);
        Task Adicionar(TipoDespesaDTO TipoDespesaDTO);
        Task Atualizar(TipoDespesaDTO TipoDespesaDTO);
        Task Apagar(int id);
    }
}
