using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface IOrcamentoRepositorio
    {
        Task<List<OrcamentoModel>> BuscarTodosOrcamento();
        Task<OrcamentoModel> BuscarPorId(int id);
        Task<OrcamentoModel> Adicionar(OrcamentoModel orcamento);
        Task<OrcamentoModel> Atualizar(OrcamentoModel orcamento);
        Task<bool> Apagar(int id);
    }
}
