using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface IDespesaRepositorio
    {
        Task<List<DespesaModel>> BuscarTodosDespesa();
        Task<DespesaModel> BuscarPorId(int id);
        Task<DespesaModel> Adicionar(DespesaModel despesa);
        Task<DespesaModel> Atualizar(DespesaModel despesa);
        Task<bool> Apagar(int id);
    }
}
