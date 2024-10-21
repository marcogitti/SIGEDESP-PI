using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;
using api.DTO.Entities;
using AutoMapper;
using api.Models.Enum;

namespace api.Repositorios
{
    public class OrcamentoRepositorio : IOrcamentoRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        private readonly IMapper _mapper;

        public OrcamentoRepositorio(SigedespDBContex sigedespDBContex, IMapper mapper)
        {
            _dbContext = sigedespDBContex;
            _mapper = mapper;  // Injeta o AutoMapper
        }

        public async Task<OrcamentoDTO> BuscarPorId(int id)
        {
            var orcamento = await _dbContext.Orcamento.AsNoTracking()
                .Include(d => d.Instituicao)
                .Include(d => d.TipoDespesa)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<OrcamentoDTO>(orcamento);  // Usa o AutoMapper para mapear para o DTO
        }

        public async Task<List<OrcamentoDTO>> BuscarTodosOrcamento()
        {
            var orcamentos = await _dbContext.Orcamento.AsNoTracking()
                .Include(d => d.Instituicao)
                .Include(d => d.TipoDespesa)
                .ToListAsync(); // Alterado para ToListAsync()

            return _mapper.Map<List<OrcamentoDTO>>(orcamentos); // Mapeia a lista para OrcamentoDTO
        }

        public async Task<OrcamentoModel> Adicionar(OrcamentoModel orcamento)
        {
            await _dbContext.Orcamento.AddAsync(orcamento);
            await _dbContext.SaveChangesAsync();

            return orcamento;
        }

        public async Task<OrcamentoModel> Atualizar(OrcamentoModel orcamento)
        {
            var orcamentoExistente = await _dbContext.Orcamento.AsNoTracking().FirstOrDefaultAsync(d => d.Id == orcamento.Id);
            if (orcamentoExistente == null)
            {
                throw new Exception($"Orçamento para o ID: {orcamento.Id} não foi encontrado no banco de dados");
            }

            _dbContext.Entry(orcamento).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return orcamento;
        }

        public async Task<bool> Apagar(int id)
        {
            var orcamentoPorId = await _dbContext.Orcamento.FindAsync(id);
            if (orcamentoPorId == null)
            {
                throw new Exception($"Orçamento para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Orcamento.Remove(orcamentoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
