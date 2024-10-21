using api.DTO.Entities;
using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface IOrcamentoRepositorio
    {
        Task<List<OrcamentoDTO>> BuscarTodosOrcamento();
        Task<OrcamentoDTO> BuscarPorId(int id);
        Task<OrcamentoModel> Adicionar(OrcamentoModel orcamento);
        Task<OrcamentoModel> Atualizar(OrcamentoModel orcamento);
        Task<bool> Apagar(int id);
    }
}
