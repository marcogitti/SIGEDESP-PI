using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface ITipoDespesaService
    {
        Task<IEnumerable<TipoDespesaDTO>> BuscarTodosTipoDespesa();
        Task<TipoDespesaDTO> BuscarPorId(int id);
        Task Adicionar(TipoDespesaAdicionarAtualizarDTO tipodespesaDTO);
        Task Atualizar(TipoDespesaAdicionarAtualizarDTO tipodespesaDTO);
        Task Apagar(int id);
    }
}
