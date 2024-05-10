using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface IInstituicaoService
    {
        Task<IEnumerable<InstituicaoDTO>> BuscarTodosInstituicao();
        Task<InstituicaoDTO> BuscarPorId(int id);
        Task Adicionar(InstituicaoDTO InstituicaoDTO);
        Task Atualizar(InstituicaoDTO InstituicaoDTO);
        Task Apagar(int id);
    }
}