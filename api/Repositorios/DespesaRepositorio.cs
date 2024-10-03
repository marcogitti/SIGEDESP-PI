using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;
using api.DTO.Entities;
using AutoMapper;
using api.Models.Enum;

namespace api.Repositorios
{
    public class DespesaRepositorio : IDespesaRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        private readonly IMapper _mapper;

        public DespesaRepositorio(SigedespDBContex sigedespDBContex, IMapper mapper)
        {
            _dbContext = sigedespDBContex;
            _mapper = mapper;  // Injeta o AutoMapper
        }

        public async Task<DespesaDTO> BuscarPorId(int id)
        {
            var despesa = await _dbContext.Despesa.AsNoTracking()
                .Include(d => d.Usuario)
                .Include(d => d.Fornecedor)
                .Include(d => d.UnidadeConsumidora)
                .Include(d => d.Instituicao)
                .Include(d => d.Orcamento)
                .Include(d => d.TipoDespesa)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<DespesaDTO>(despesa);  // Usa o AutoMapper para mapear para o DTO
        }

        public async Task<List<DespesaDTO>> BuscarTodosDespesa()
        {
            var despesas = await _dbContext.Despesa.AsNoTracking()
                .Include(d => d.Usuario)
                .Include(d => d.Fornecedor)
                .Include(d => d.UnidadeConsumidora)
                .Include(d => d.Instituicao)
                .Include(d => d.Orcamento)
                .Include(d => d.TipoDespesa)
                .ToListAsync(); // Alterado para ToListAsync()

            return _mapper.Map<List<DespesaDTO>>(despesas); // Mapeia a lista para DespesaDTO
        }

        public async Task<DespesaModel> Adicionar(DespesaModel despesa)
        {
            if (!Enum.IsDefined(typeof(EnumStatusDespesaModel), despesa.StatusDespesa))
            {
                throw new ArgumentException("Tipo de status de despesa inválido");
            }

            await _dbContext.Despesa.AddAsync(despesa);
            await _dbContext.SaveChangesAsync();

            return despesa;
        }

        public async Task<DespesaModel> Atualizar(DespesaModel despesa)
        {
            var despesaExistente = await _dbContext.Despesa.AsNoTracking().FirstOrDefaultAsync(d => d.Id == despesa.Id);
            if (despesaExistente == null)
            {
                throw new Exception($"Despesa para o ID: {despesa.Id} não foi encontrada no banco de dados");
            }

            _dbContext.Entry(despesa).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return despesa;
        }

        public async Task<bool> Apagar(int id)
        {
            var despesaPorId = await _dbContext.Despesa.FindAsync(id);
            if (despesaPorId == null)
            {
                throw new Exception($"Despesa para o ID: {id} não foi encontrada no banco de dados");
            }

            _dbContext.Despesa.Remove(despesaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
