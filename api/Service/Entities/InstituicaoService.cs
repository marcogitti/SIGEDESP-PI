using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;

namespace api.Services.Entities;
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
        var instituicao = await _instituicaoRepositorio.BuscarTodosInstituicao();
        return _mapper.Map<IEnumerable<InstituicaoDTO>>(instituicao);
    }

    public async Task<InstituicaoDTO> BuscarPorId(int id)
    {
        var instituicao = await _instituicaoRepositorio.BuscarPorId(id);
        return _mapper.Map<InstituicaoDTO>(instituicao);
    }

    public async Task Adicionar(InstituicaoDTO instituicaoDTO)
    {
        var instituicao = _mapper.Map<InstituicaoModel>(instituicaoDTO);
        await _instituicaoRepositorio.Adicionar(instituicao);
        instituicaoDTO.Id = instituicao.Id;
    }

    public async Task Atualizar(InstituicaoDTO instituicaoDTO)
    {
        var instituicao = _mapper.Map<InstituicaoModel>(instituicaoDTO);
        await _instituicaoRepositorio.Atualizar(instituicao);
    }

    public async Task Apagar(int id)
    {
        await _instituicaoRepositorio.Apagar(id);
    }
}