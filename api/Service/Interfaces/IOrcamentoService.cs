using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface IOrcamentoService
    {
        Task<IEnumerable<OrcamentoDTO>> BuscarTodosOrcamento();
        Task<OrcamentoDTO> BuscarPorId(int id);
        Task Adicionar(OrcamentoAdicionarAtualizarDTO orcamentoDTO);
        Task Atualizar(OrcamentoAdicionarAtualizarDTO orcamentoDTO);
        Task Apagar(int id);
    }
}
