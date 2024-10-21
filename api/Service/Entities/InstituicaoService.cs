using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services.Entities
{
    public class InstituicaoService : IInstituicaoService
    {
        private readonly IInstituicaoRepositorio _instituicaoRepositorio;
        private readonly IMapper _mapper;

        public InstituicaoService(IInstituicaoRepositorio instituicaoRepositorio, IMapper mapper)
        {
            _instituicaoRepositorio = instituicaoRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstituicaoDTO>> BuscarTodosInstituicao()
        {
            var instituicoes = await _instituicaoRepositorio.BuscarTodosInstituicao();
            return _mapper.Map<IEnumerable<InstituicaoDTO>>(instituicoes);
        }

        public async Task<InstituicaoDTO> BuscarPorId(int id)
        {
            var instituicao = await _instituicaoRepositorio.BuscarPorId(id);
            return _mapper.Map<InstituicaoDTO>(instituicao);
        }

        public async Task Adicionar(InstituicaoAdicionarAtualizarDTO instituicaoDTO)
        {
            try
            {
                var instituicao = _mapper.Map<InstituicaoModel>(instituicaoDTO);
                await _instituicaoRepositorio.Adicionar(instituicao);
                instituicaoDTO.Id = instituicao.Id; // Atribuindo o ID gerado
            }
            catch (Exception ex)
            {
                // Log e tratar a exceção de maneira apropriada
                throw new Exception("Erro ao adicionar instituição: " + ex.Message);
            }
        }

        public async Task Atualizar(InstituicaoAdicionarAtualizarDTO instituicaoDTO)
        {
            var instituicao = _mapper.Map<InstituicaoModel>(instituicaoDTO);
            await _instituicaoRepositorio.Atualizar(instituicao);
        }

        public async Task Apagar(int id)
        {
            await _instituicaoRepositorio.Apagar(id);
        }
    }
}
