using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface IFornecedorRepositorio
    {
        Task<List<FornecedorModel>> BuscarTodosFornecedor();
        Task<FornecedorModel> BuscarPorId(int id);
        Task<FornecedorModel> Adicionar(FornecedorModel fornecedor);
        Task<FornecedorModel> Atualizar(FornecedorModel fornecedor);
        Task<bool> Apagar(int id);
    }
}
