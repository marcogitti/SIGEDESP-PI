using api.DTO.Entities;
using api.Models;

namespace api.Repositorios.Interfaces
{
    public interface ITipoDespesaRepositorio
    {
        Task<List<TipoDespesaDTO>> BuscarTodosTipoDespesa();
        Task<TipoDespesaDTO> BuscarPorId(int id);
        Task<TipoDespesaModel> Adicionar(TipoDespesaModel tipoDespesa);
        Task<TipoDespesaModel> Atualizar(TipoDespesaModel tipoDespesa);
        Task<bool> Apagar(int id);
    }
}
