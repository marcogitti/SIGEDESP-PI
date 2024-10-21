using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface IInstituicaoService
    {
        Task<IEnumerable<InstituicaoDTO>> BuscarTodosInstituicao();
        Task<InstituicaoDTO> BuscarPorId(int id);
        Task Adicionar(InstituicaoAdicionarAtualizarDTO instituicaoDTO);
        Task Atualizar(InstituicaoAdicionarAtualizarDTO instituicaoDTO);
        Task Apagar(int id);
    }
}