using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Repositorios;

namespace api.Services.Entities
{
    public class TipoDespesaService : ITipoDespesaService
    {
        private readonly ITipoDespesaRepositorio _tipodespesaRepositorio;
        private readonly IMapper _mapper;

        public TipoDespesaService(ITipoDespesaRepositorio tipodespesaRepositorio, IMapper mapper)
        {
            _tipodespesaRepositorio = tipodespesaRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoDespesaDTO>> BuscarTodosTipoDespesa()
        {
            var tipodespesas = await _tipodespesaRepositorio.BuscarTodosTipoDespesa();
            return _mapper.Map<IEnumerable<TipoDespesaDTO>>(tipodespesas);
        }

        public async Task<TipoDespesaDTO> BuscarPorId(int id)
        {
            var tipodespesa = await _tipodespesaRepositorio.BuscarPorId(id);
            return _mapper.Map<TipoDespesaDTO>(tipodespesa);
        }

        public async Task Adicionar(TipoDespesaAdicionarAtualizarDTO tipodespesaDTO)
        {
            try
            {
                var tipodespesa = _mapper.Map<TipoDespesaModel>(tipodespesaDTO);
                await _tipodespesaRepositorio.Adicionar(tipodespesa);
                tipodespesaDTO.Id = tipodespesa.Id; // Atribuindo o ID gerado
            }
            catch (Exception ex)
            {
                // Log e tratar a exceção de maneira apropriada
                throw new Exception("Erro ao adicionar tipo despesa: " + ex.Message);
            }
        }

        public async Task Atualizar(TipoDespesaAdicionarAtualizarDTO tipodespesaDTO)
        {
            var tipodespesa = _mapper.Map<TipoDespesaModel>(tipodespesaDTO);
            await _tipodespesaRepositorio.Atualizar(tipodespesa);
        }

        public async Task Apagar(int id)
        {
            await _tipodespesaRepositorio.Apagar(id);
        }
    }
}
