using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;

namespace api.Services.Entities;
public class UsuarioService : IUsuarioService
{

    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioDTO>> BuscarTodosUsuario()
    {
        var usuario = await _usuarioRepositorio.BuscarTodosUsuario();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuario);
    }

    public async Task<UsuarioDTO> BuscarPorId(int id)
    {
        var usuario = await _usuarioRepositorio.BuscarPorId(id);
        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task Adicionar(UsuarioDTO usuarioDTO)
    {
        var usuario = _mapper.Map<UsuarioModel>(usuarioDTO);
        await _usuarioRepositorio.Adicionar(usuario);
        usuarioDTO.Id = usuario.Id;
    }

    public async Task Atualizar(UsuarioDTO usuarioDTO)
    {
        var usuario = _mapper.Map<UsuarioModel>(usuarioDTO);
        await _usuarioRepositorio.Atualizar(usuario);
    }

    public async Task Apagar(int id)
    {
        await _usuarioRepositorio.Apagar(id);
    }
}