using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositorios.Interfaces;

namespace api.Repositorios
{
    public class TipoInstituicaoRepositorio : ITipoInstituicaoRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        public TipoInstituicaoRepositorio(SigedespDBContex sigedespDBContex)
        {
            _dbContext = sigedespDBContex;
        }

        public async Task<TipoInstituicaoModel> BuscarPorId(int id)
        {
            return await _dbContext.TipoInstituicao.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TipoInstituicaoModel>> BuscarTodosTipoInstituicao()
        {
            return await _dbContext.TipoInstituicao.ToListAsync();
        }

        public async Task<TipoInstituicaoModel> Adicionar(TipoInstituicaoModel tipoInstituicao)
        {
            await _dbContext.TipoInstituicao.AddAsync(tipoInstituicao);
            await _dbContext.SaveChangesAsync();

            return tipoInstituicao;
        }

        public async Task<TipoInstituicaoModel> Atualizar(TipoInstituicaoModel tipoInstituicao)
        {
            _dbContext.Entry(tipoInstituicao).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return tipoInstituicao;
        }

        public async Task<bool> Apagar(int id)
        {
            TipoInstituicaoModel tipoInstituicaoPorId = await BuscarPorId(id);

            if (tipoInstituicaoPorId == null)
            {
                throw new Exception($"Tipo Instituição para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.TipoInstituicao.Remove(tipoInstituicaoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}