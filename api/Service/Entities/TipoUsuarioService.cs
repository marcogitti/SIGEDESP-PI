using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;

namespace api.Services.Entities;
public class TipoUsuarioService : ITipoUsuarioService
{

    private readonly ITipoUsuarioRepositorio _tipoUsuarioRepositorio;
    private readonly IMapper _mapper;

    public TipoUsuarioService(ITipoUsuarioRepositorio tipoUsuarioRepositorio, IMapper mapper)
    {
        _tipoUsuarioRepositorio = tipoUsuarioRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TipoUsuarioDTO>> BuscarTodosTipoUsuario()
    {
        var tipoUsuario = await _tipoUsuarioRepositorio.BuscarTodosTipoUsuario();
        return _mapper.Map<IEnumerable<TipoUsuarioDTO>>(tipoUsuario);
    }

    public async Task<TipoUsuarioDTO> BuscarPorId(int id)
    {
        var tipoUsuario = await _tipoUsuarioRepositorio.BuscarPorId(id);
        return _mapper.Map<TipoUsuarioDTO>(tipoUsuario);
    }

    public async Task Adicionar(TipoUsuarioDTO tipoUsuarioDTO)
    {
        var tipoUsuario = _mapper.Map<TipoUsuarioModel>(tipoUsuarioDTO);
        await _tipoUsuarioRepositorio.Adicionar(tipoUsuario);
        tipoUsuarioDTO.Id = tipoUsuario.Id;
    }

    public async Task Atualizar(TipoUsuarioDTO tipoUsuarioDTO)
    {
        var tipoUsuario = _mapper.Map<TipoUsuarioModel>(tipoUsuarioDTO);
        await _tipoUsuarioRepositorio.Atualizar(tipoUsuario);
    }

    public async Task Apagar(int id)
    {
        await _tipoUsuarioRepositorio.Apagar(id);
    }
}