using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface IUnidadeMedidaRepositorio
    {
        Task<List<UnidadeMedidaModel>> BuscarTodosUnidadeMedida();
        Task<UnidadeMedidaModel> BuscarPorId(int id);
        Task<UnidadeMedidaModel> Adicionar(UnidadeMedidaModel unidadeMedida);
        Task<UnidadeMedidaModel> Atualizar(UnidadeMedidaModel unidadeMedida);
        Task<bool> Apagar(int id);
    }
}
