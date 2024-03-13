using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Models;
using api.Repositorios.Interfaces;

namespace api.Services.Entities;
public class UnidadeConsumidoraService : IUnidadeConsumidoraService
{

    private readonly IUnidadeConsumidoraRepositorio _unidadeConsumidoraRepositorio;
    private readonly IMapper _mapper;

    public UnidadeConsumidoraService(IUnidadeConsumidoraRepositorio unidadeConsumidoraRepositorio, IMapper mapper)
    {
        _unidadeConsumidoraRepositorio = unidadeConsumidoraRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UnidadeConsumidoraDTO>> BuscarTodosUnidadeConsumidora()
    {
        var unidadeConsumidora = await _unidadeConsumidoraRepositorio.BuscarTodosUnidadeConsumidora();
        return _mapper.Map<IEnumerable<UnidadeConsumidoraDTO>>(unidadeConsumidora);
    }

    public async Task<UnidadeConsumidoraDTO> BuscarPorId(int id)
    {
        var unidadeConsumidora = await _unidadeConsumidoraRepositorio.BuscarPorId(id);
        return _mapper.Map<UnidadeConsumidoraDTO>(unidadeConsumidora);
    }

    public async Task Adicionar(UnidadeConsumidoraDTO unidadeConsumidoraDTO)
    {
        var unidadeConsumidora = _mapper.Map<UnidadeConsumidoraModel>(unidadeConsumidoraDTO);
        await _unidadeConsumidoraRepositorio.Adicionar(unidadeConsumidora);
        unidadeConsumidoraDTO.Id = unidadeConsumidora.Id;
    }

    public async Task Atualizar(UnidadeConsumidoraDTO unidadeConsumidoraDTO)
    {
        var unidadeConsumidora = _mapper.Map<UnidadeConsumidoraModel>(unidadeConsumidoraDTO);
        await _unidadeConsumidoraRepositorio.Atualizar(unidadeConsumidora);
    }

    public async Task Apagar(int id)
    {
        await _unidadeConsumidoraRepositorio.Apagar(id);
    }
}