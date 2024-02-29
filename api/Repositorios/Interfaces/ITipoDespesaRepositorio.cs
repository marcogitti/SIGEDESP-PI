using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface ITipoDespesaRepositorio
    {
        Task<List<TipoDespesaModel>> BuscarTodosTipoDespesa();
        Task<TipoDespesaModel> BuscarPorId(int id);
        Task<TipoDespesaModel> Adicionar(TipoDespesaModel tipoDespesa);
        Task<TipoDespesaModel> Atualizar(TipoDespesaModel tipoDespesa);
        Task<bool> Apagar(int id);
    }
}
