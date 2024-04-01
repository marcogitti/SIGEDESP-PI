using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface IUnidadeConsumidoraRepositorio
    {
        Task<List<UnidadeConsumidoraModel>> BuscarTodosUnidadeConsumidora();
        Task<UnidadeConsumidoraModel> BuscarPorId(int id);
        Task<UnidadeConsumidoraModel> Adicionar(UnidadeConsumidoraModel unidadeConsumidora);
        Task<UnidadeConsumidoraModel> Atualizar(UnidadeConsumidoraModel unidadeConsumidora);
        Task<bool> Apagar(int id);
    }
}