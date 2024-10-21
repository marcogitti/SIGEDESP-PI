using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;
using api.DTO.Entities;
using AutoMapper;

namespace api.Repositorios
{
    public class UnidadeConsumidoraRepositorio : IUnidadeConsumidoraRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        private readonly IMapper _mapper;

        public UnidadeConsumidoraRepositorio(SigedespDBContex sigedespDBContex, IMapper mapper)
        {
            _dbContext = sigedespDBContex;
            _mapper = mapper;  // Injeta o AutoMapper
        }

        public async Task<UnidadeConsumidoraDTO> BuscarPorId(int id)
        {
            var unidadeConsumidora = await _dbContext.Despesa.AsNoTracking()
                .Include(d => d.Fornecedor)
                .Include(d => d.Instituicao)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<UnidadeConsumidoraDTO>(unidadeConsumidora);  // Usa o AutoMapper para mapear para o DTO
        }

        public async Task<List<UnidadeConsumidoraDTO>> BuscarTodosUnidadeConsumidora()
        {
            var unidadesConsumidoras = await _dbContext.UnidadeConsumidora.AsNoTracking()
                .Include(d => d.Fornecedor)
                .Include(d => d.Instituicao)
                .ToListAsync(); // Alterado para ToListAsync()

            return _mapper.Map<List<UnidadeConsumidoraDTO>>(unidadesConsumidoras); // Mapeia a lista para UnidadeConsumidoraDTO
        }

        public async Task<UnidadeConsumidoraModel> Adicionar(UnidadeConsumidoraModel unidadeConsumidora)
        {
            await _dbContext.UnidadeConsumidora.AddAsync(unidadeConsumidora);
            await _dbContext.SaveChangesAsync();

            return unidadeConsumidora;
        }

        public async Task<UnidadeConsumidoraModel> Atualizar(UnidadeConsumidoraModel unidadeConsumidora)
        {
            var unidadeconsumidoraExistente = await _dbContext.UnidadeConsumidora.AsNoTracking().FirstOrDefaultAsync(d => d.Id == unidadeConsumidora.Id);
            if (unidadeconsumidoraExistente == null)
            {
                throw new Exception($"Unidade Consumidora para o ID: {unidadeConsumidora.Id} não foi encontrada no banco de dados");
            }

            _dbContext.Entry(unidadeConsumidora).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return unidadeConsumidora;
        }

        public async Task<bool> Apagar(int id)
        {
            var unidadeconsumidoraPorId = await _dbContext.UnidadeConsumidora.FindAsync(id);
            if (unidadeconsumidoraPorId == null)
            {
                throw new Exception($"Unidade Consumidora para o ID: {id} não foi encontrada no banco de dados");
            }

            _dbContext.UnidadeConsumidora.Remove(unidadeconsumidoraPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
