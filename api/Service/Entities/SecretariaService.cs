using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;

namespace api.Services.Entities;
public class SecretariaService : ISecretariaService
{

    private readonly ISecretariaRepositorio _secretariaRepositorio;
    private readonly IMapper _mapper;

    public SecretariaService(ISecretariaRepositorio secretariaRepositorio, IMapper mapper)
    {
        _secretariaRepositorio = secretariaRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SecretariaDTO>> BuscarTodosSecretaria()
    {
        var secretaria = await _secretariaRepositorio.BuscarTodosSecretaria();
        return _mapper.Map<IEnumerable<SecretariaDTO>>(secretaria);
    }

    public async Task<SecretariaDTO> BuscarPorId(int id)
    {
        var secretaria = await _secretariaRepositorio.BuscarPorId(id);
        return _mapper.Map<SecretariaDTO>(secretaria);
    }

    public async Task Adicionar(SecretariaDTO secretariaDTO)
    {
        var secretaria = _mapper.Map<SecretariaModel>(secretariaDTO);
        await _secretariaRepositorio.Adicionar(secretaria);
        secretariaDTO.Id = secretaria.Id;
    }

    public async Task Atualizar(SecretariaDTO secretariaDTO)
    {
        var secretaria = _mapper.Map<SecretariaModel>(secretariaDTO);
        await _secretariaRepositorio.Atualizar(secretaria);
    }

    public async Task Apagar(int id)
    {
        await _secretariaRepositorio.Apagar(id);
    }
}