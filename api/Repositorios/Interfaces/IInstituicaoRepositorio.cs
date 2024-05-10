using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface IInstituicaoRepositorio
    {
        Task<List<InstituicaoModel>> BuscarTodosInstituicao();
        Task<InstituicaoModel> BuscarPorId(int id);
        Task<InstituicaoModel> Adicionar(InstituicaoModel Instituicao);
        Task<InstituicaoModel> Atualizar(InstituicaoModel Instituicao);
        Task<bool> Apagar(int id);
    }
}
