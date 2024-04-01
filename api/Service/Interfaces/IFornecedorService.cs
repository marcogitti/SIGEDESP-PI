using api.DTO.Entities;

namespace api.Service.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorDTO>> BuscarTodosFornecedor();
        Task<FornecedorDTO> BuscarPorId(int id);
        Task Adicionar(FornecedorDTO FornecedorDTO);
        Task Atualizar(FornecedorDTO FornecedorDTO);
        Task Apagar(int id);
    }
}