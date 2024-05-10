using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;

namespace api.Repositorios
{
    public class InstituicaoRepositorio : IInstituicaoRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        public InstituicaoRepositorio(SigedespDBContex sigedespDBContex)
        {
            _dbContext = sigedespDBContex;
        }

        public async Task<InstituicaoModel> BuscarPorId(int id)
        {
            return await _dbContext.Instituicao.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<InstituicaoModel>> BuscarTodosInstituicao()
        {
            return await _dbContext.Instituicao.ToListAsync();
        }

        public async Task<InstituicaoModel> Adicionar(InstituicaoModel Instituicao)
        {
            await _dbContext.Instituicao.AddAsync(Instituicao);
            await _dbContext.SaveChangesAsync();

            return Instituicao;
        }

        public async Task<InstituicaoModel> Atualizar(InstituicaoModel Instituicao)
        {
            _dbContext.Entry(Instituicao).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Instituicao;
        }

        public async Task<bool> Apagar(int id)
        {
            InstituicaoModel InstituicaoPorId = await BuscarPorId(id);

            if (InstituicaoPorId == null)
            {
                throw new Exception($"Instituicao para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Instituicao.Remove(InstituicaoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
