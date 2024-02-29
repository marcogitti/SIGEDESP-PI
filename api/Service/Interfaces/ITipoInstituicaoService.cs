using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface ITipoInstituicaoService
    {
        Task<IEnumerable<TipoInstituicaoDTO>> BuscarTodosTipoInstituicao();
        Task<TipoInstituicaoDTO> BuscarPorId(int id);
        Task Adicionar(TipoInstituicaoDTO TipoInstituicaoDTO);
        Task Atualizar(TipoInstituicaoDTO TipoInstituicaoDTO);
        Task Apagar(int id);
    }
}
