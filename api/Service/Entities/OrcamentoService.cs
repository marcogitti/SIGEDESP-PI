using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services.Entities
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IOrcamentoRepositorio _orcamentoRepositorio;
        private readonly IMapper _mapper;

        public OrcamentoService(IOrcamentoRepositorio orcamentoRepositorio, IMapper mapper)
        {
            _orcamentoRepositorio = orcamentoRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrcamentoDTO>> BuscarTodosOrcamento()
        {
            var orcamentos = await _orcamentoRepositorio.BuscarTodosOrcamento();
            return _mapper.Map<IEnumerable<OrcamentoDTO>>(orcamentos);
        }

        public async Task<OrcamentoDTO> BuscarPorId(int id)
        {
            var orcamento = await _orcamentoRepositorio.BuscarPorId(id);
            return _mapper.Map<OrcamentoDTO>(orcamento);
        }

        public async Task Adicionar(OrcamentoAdicionarAtualizarDTO orcamentoDTO)
        {
            try
            {
                var orcamento = _mapper.Map<OrcamentoModel>(orcamentoDTO);
                await _orcamentoRepositorio.Adicionar(orcamento);
                orcamentoDTO.Id = orcamento.Id; // Atribuindo o ID gerado
            }
            catch (Exception ex)
            {
                // Log e tratar a exceção de maneira apropriada
                throw new Exception("Erro ao adicionar orçamento: " + ex.Message);
            }
        }

        public async Task Atualizar(OrcamentoAdicionarAtualizarDTO orcamentoDTO)
        {
            var orcamento = _mapper.Map<OrcamentoModel>(orcamentoDTO);
            await _orcamentoRepositorio.Atualizar(orcamento);
        }

        public async Task Apagar(int id)
        {
            await _orcamentoRepositorio.Apagar(id);
        }
    }
}
