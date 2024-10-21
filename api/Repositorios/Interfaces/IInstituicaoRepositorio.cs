using api.DTO.Entities;
using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface IInstituicaoRepositorio
    {
        Task<List<InstituicaoDTO>> BuscarTodosInstituicao();
        Task<InstituicaoDTO> BuscarPorId(int id);
        Task<InstituicaoModel> Adicionar(InstituicaoModel instituicao);
        Task<InstituicaoModel> Atualizar(InstituicaoModel instituicao);
        Task<bool> Apagar(int id);
    }
}
