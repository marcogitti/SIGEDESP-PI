using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services.Entities
{
    public class UnidadeConsumidoraService : IUnidadeConsumidoraService
    {
        private readonly IUnidadeConsumidoraRepositorio _unidadeconsumidoraRepositorio;
        private readonly IMapper _mapper;

        public UnidadeConsumidoraService(IUnidadeConsumidoraRepositorio unidadeConsumidoraRepositorio, IMapper mapper)
        {
            _unidadeconsumidoraRepositorio = unidadeConsumidoraRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UnidadeConsumidoraDTO>> BuscarTodosUnidadeConsumidora()
        {
            var unidadesConsumidoras = await _unidadeconsumidoraRepositorio.BuscarTodosUnidadeConsumidora();
            return _mapper.Map<IEnumerable<UnidadeConsumidoraDTO>>(unidadesConsumidoras);
        }

        public async Task<UnidadeConsumidoraDTO> BuscarPorId(int id)
        {
            var unidadeConsumidora = await _unidadeconsumidoraRepositorio.BuscarPorId(id);
            return _mapper.Map<UnidadeConsumidoraDTO>(unidadeConsumidora);
        }

        public async Task Adicionar(UnidadeConsumidoraAdicionarAtualizarDTO unidadadeconsumidoraDTO)
        {
            try
            {
                var unidadeConsumidora = _mapper.Map<UnidadeConsumidoraModel>(unidadadeconsumidoraDTO);
                await _unidadeconsumidoraRepositorio.Adicionar(unidadeConsumidora);
                unidadadeconsumidoraDTO.Id = unidadeConsumidora.Id; // Atribuindo o ID gerado
            }
            catch (Exception ex)
            {
                // Log e tratar a exceção de maneira apropriada
                throw new Exception("Erro ao adicionar unidade consumidora: " + ex.Message);
            }
        }

        public async Task Atualizar(UnidadeConsumidoraAdicionarAtualizarDTO unidadeconsumidoraDTO)
        {
            var unidadeConsumidora = _mapper.Map<UnidadeConsumidoraModel>(unidadeconsumidoraDTO);
            await _unidadeconsumidoraRepositorio.Atualizar(unidadeConsumidora);
        }

        public async Task Apagar(int id)
        {
            await _unidadeconsumidoraRepositorio.Apagar(id);
        }
    }
}
