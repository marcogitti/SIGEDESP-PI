using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface ISecretariaRepositorio
    {
        Task<List<SecretariaModel>> BuscarTodosSecretaria();
        Task<SecretariaModel> BuscarPorId(int id);
        Task<SecretariaModel> Adicionar(SecretariaModel secretaria);
        Task<SecretariaModel> Atualizar(SecretariaModel secretaria);
        Task<bool> Apagar(int id);
    }
}