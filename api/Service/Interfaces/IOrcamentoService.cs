using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface IOrcamentoService
    {
        Task<IEnumerable<OrcamentoDTO>> BuscarTodosOrcamento();
        Task<OrcamentoDTO> BuscarPorId(int id);
        Task Adicionar(OrcamentoDTO OrcamentoDTO);
        Task Atualizar(OrcamentoDTO OrcamentoDTO);
        Task Apagar(int id);
    }
}