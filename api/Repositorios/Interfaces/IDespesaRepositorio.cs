using api.Models;
using api.DTO.Entities; // Supondo que o DTO esteja neste namespace

namespace api.Repositorios.Interfaces
{
    public interface IDespesaRepositorio
    {
        Task<List<DespesaDTO>> BuscarTodosDespesa();
        Task<DespesaDTO> BuscarPorId(int id); // Alterado para retornar DespesaDTO
        Task<DespesaModel> Adicionar(DespesaModel despesa);
        Task<DespesaModel> Atualizar(DespesaModel despesa);
        Task<bool> Apagar(int id);
    }
}