using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface ITipoInstituicaoRepositorio
    {
        Task<List<TipoInstituicaoModel>> BuscarTodosTipoInstituicao();
        Task<TipoInstituicaoModel> BuscarPorId(int id);
        Task<TipoInstituicaoModel> Adicionar(TipoInstituicaoModel tipoInstituicao);
        Task<TipoInstituicaoModel> Atualizar(TipoInstituicaoModel tipoInstituicao);
        Task<bool> Apagar(int id);
    }
}
