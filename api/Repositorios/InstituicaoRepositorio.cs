using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;
using api.DTO.Entities;
using AutoMapper;
using api.Models.Enum;

namespace api.Repositorios
{
    public class InstituicaoRepositorio : IInstituicaoRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        private readonly IMapper _mapper;

        public InstituicaoRepositorio(SigedespDBContex sigedespDBContex, IMapper mapper)
        {
            _dbContext = sigedespDBContex;
            _mapper = mapper;  // Injeta o AutoMapper
        }

        public async Task<InstituicaoDTO> BuscarPorId(int id)
        {
            var instituicao = await _dbContext.Instituicao.AsNoTracking()
                .Include(d => d.Secretaria)
                .Include(d => d.TipoInstituicao)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<InstituicaoDTO>(instituicao);  // Usa o AutoMapper para mapear para o DTO
        }

        public async Task<List<InstituicaoDTO>> BuscarTodosInstituicao()
        {
            var instituicoes = await _dbContext.Instituicao.AsNoTracking()
                .Include(d => d.Secretaria)
                .Include(d => d.TipoInstituicao)
                .ToListAsync(); // Alterado para ToListAsync()

            return _mapper.Map<List<InstituicaoDTO>>(instituicoes); // Mapeia a lista para DespesaDTO
        }

        public async Task<InstituicaoModel> Adicionar(InstituicaoModel instituicao)
        {
            await _dbContext.Instituicao.AddAsync(instituicao);
            await _dbContext.SaveChangesAsync();

            return instituicao;
        }

        public async Task<InstituicaoModel> Atualizar(InstituicaoModel instituicao)
        {
            var instituicaoExistente = await _dbContext.Instituicao.AsNoTracking().FirstOrDefaultAsync(d => d.Id == instituicao.Id);
            if (instituicaoExistente == null)
            {
                throw new Exception($"Instituição para o ID: {instituicao.Id} não foi encontrada no banco de dados");
            }

            _dbContext.Entry(instituicao).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return instituicao;
        }

        public async Task<bool> Apagar(int id)
        {
            var instituicaoPorId = await _dbContext.Instituicao.FindAsync(id);
            if (instituicaoPorId == null)
            {
                throw new Exception($"Instituição para o ID: {id} não foi encontrada no banco de dados");
            }

            _dbContext.Instituicao.Remove(instituicaoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
