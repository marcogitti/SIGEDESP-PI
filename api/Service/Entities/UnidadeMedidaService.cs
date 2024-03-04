using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;
using api.Repositorios;

namespace api.Services.Entities;
public class UnidadeMedidaService : IUnidadeMedidaService
{

    private readonly IUnidadeMedidaRepositorio _unidadeMedidaRepositorio;
    private readonly IMapper _mapper;

    public UnidadeMedidaService(IUnidadeMedidaRepositorio unidadeMedidaRepositorio, IMapper mapper)
    {
        _unidadeMedidaRepositorio = unidadeMedidaRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UnidadeMedidaDTO>> BuscarTodosUnidadeMedida()
    {
        var unidadeMedida = await _unidadeMedidaRepositorio.BuscarTodosUnidadeMedida();
        return _mapper.Map<IEnumerable<UnidadeMedidaDTO>>(unidadeMedida);
    }

    public async Task<UnidadeMedidaDTO> BuscarPorId(int id)
    {
        var unidadeMedida = await _unidadeMedidaRepositorio.BuscarPorId(id);
        return _mapper.Map<UnidadeMedidaDTO>(unidadeMedida);
    }

    public async Task Adicionar(UnidadeMedidaDTO unidadeMedidaDTO)
    {
        var unidadeMedida = _mapper.Map<UnidadeMedidaModel>(unidadeMedidaDTO);
        await _unidadeMedidaRepositorio.Adicionar(unidadeMedida);
        unidadeMedidaDTO.Id = unidadeMedida.Id;
    }

    public async Task Atualizar(UnidadeMedidaDTO unidadeMedidaDTO)
    {
        var unidadeMedida = _mapper.Map<UnidadeMedidaModel>(unidadeMedidaDTO);
        await _unidadeMedidaRepositorio.Atualizar(unidadeMedida);
    }

    public async Task Apagar(int id)
    {
        await _unidadeMedidaRepositorio.Apagar(id);
    }
}