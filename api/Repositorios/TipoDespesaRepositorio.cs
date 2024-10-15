using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;
using api.DTO.Entities;
using AutoMapper;
using api.Models.Enum;

namespace api.Repositorios
{
    public class TipoDespesaRepositorio : ITipoDespesaRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        private readonly IMapper _mapper;

        public TipoDespesaRepositorio(SigedespDBContex sigedespDBContex, IMapper mapper)
        {
            _dbContext = sigedespDBContex;
            _mapper = mapper;  // Injeta o AutoMapper
        }

        public async Task<TipoDespesaDTO> BuscarPorId(int id)
        {
            var tipodespesa = await _dbContext.TipoDespesa.AsNoTracking()
                .Include(d => d.UnidadeMedida)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<TipoDespesaDTO>(tipodespesa);  // Usa o AutoMapper para mapear para o DTO
        }

        public async Task<List<TipoDespesaDTO>> BuscarTodosTipoDespesa()
        {
            var tipodespesas = await _dbContext.TipoDespesa.AsNoTracking()
                .Include(d => d.UnidadeMedida)
                .ToListAsync(); // Alterado para ToListAsync()

            return _mapper.Map<List<TipoDespesaDTO>>(tipodespesas); // Mapeia a lista para TipoDespesaDTO
        }

        public async Task<TipoDespesaModel> Adicionar(TipoDespesaModel tipodespesa)
        {
            if (!Enum.IsDefined(typeof(EnumSolicitaUCModel), tipodespesa.SolicitaUC))
            {
                throw new ArgumentException("Solicita Unidade Consumidora inválido");
            }

            await _dbContext.TipoDespesa.AddAsync(tipodespesa);
            await _dbContext.SaveChangesAsync();

            return tipodespesa;
        }

        public async Task<TipoDespesaModel> Atualizar(TipoDespesaModel tipodespesa)
        {
            var tipodespesaExistente = await _dbContext.TipoDespesa.AsNoTracking().FirstOrDefaultAsync(d => d.Id == tipodespesa.Id);
            if (tipodespesaExistente == null)
            {
                throw new Exception($"Tipo Despesa para o ID: {tipodespesa.Id} não foi encontrado no banco de dados");
            }

            _dbContext.Entry(tipodespesa).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return tipodespesa;
        }

        public async Task<bool> Apagar(int id)
        {
            var tipodespesaPorId = await _dbContext.TipoDespesa.FindAsync(id);
            if (tipodespesaPorId == null)
            {
                throw new Exception($"Tipo Despesa para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.TipoDespesa.Remove(tipodespesaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
