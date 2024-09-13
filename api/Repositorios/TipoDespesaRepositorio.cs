using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;
using api.Models.Enum;

namespace api.Repositorios
{
    public class TipoDespesaRepositorio : ITipoDespesaRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        public TipoDespesaRepositorio(SigedespDBContex sigedespDBContex) 
        {
            _dbContext = sigedespDBContex;
        }

        public async Task<TipoDespesaModel> BuscarPorId(int id)
        {
           return await _dbContext.TipoDespesa.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TipoDespesaModel>> BuscarTodosTipoDespesa()
        {
           return await _dbContext.TipoDespesa.ToListAsync();
        }

        public async Task<TipoDespesaModel> Adicionar(TipoDespesaModel tipoDespesa)
        {
            if (!Enum.IsDefined(typeof(EnumSolicitaUCModel), tipoDespesa.SolicitaUC))
            {
                throw new ArgumentException("Tipo de unidade consumidora inválido");
            }

            await _dbContext.TipoDespesa.AddAsync(tipoDespesa);
           await _dbContext.SaveChangesAsync();

            return tipoDespesa;
        }

        public async Task<TipoDespesaModel> Atualizar(TipoDespesaModel tipoDespesa)
        {
            _dbContext.Entry(tipoDespesa).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return tipoDespesa;
        }

        public async Task<bool> Apagar(int id)
        {
            TipoDespesaModel tipoDespesaPorId = await BuscarPorId(id);

            if (tipoDespesaPorId == null)
            {
                throw new Exception($"Tipo Despesa para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.TipoDespesa.Remove(tipoDespesaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
