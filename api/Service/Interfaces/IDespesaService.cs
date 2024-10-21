using api.DTO.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Service.Interfaces
{
    public interface IDespesaService
    {
        Task<IEnumerable<DespesaDTO>> BuscarTodosDespesa();
        Task<DespesaDTO> BuscarPorId(int id);
        Task Adicionar(DespesaAdicionarAtualizarDTO despesaDTO); // Alterado para DespesaAdicionarAtualizarDTO
        Task Atualizar(DespesaAdicionarAtualizarDTO despesaDTO); // Alterado para DespesaAdicionarAtualizarDTO
        Task Apagar(int id);
    }
}
