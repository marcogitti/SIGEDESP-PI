using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Models;
using api.Repositorios.Interfaces;

namespace api.Services.Entities;
public class TipoInstituicaoService : ITipoInstituicaoService
{

    private readonly ITipoInstituicaoRepositorio _tipoInstituicaoRepositorio;
    private readonly IMapper _mapper;

    public TipoInstituicaoService(ITipoInstituicaoRepositorio tipoInstituicaoRepositorio, IMapper mapper)
    {
        _tipoInstituicaoRepositorio = tipoInstituicaoRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TipoInstituicaoDTO>> BuscarTodosTipoInstituicao()
    {
        var tipoInstituicao = await _tipoInstituicaoRepositorio.BuscarTodosTipoInstituicao();
        return _mapper.Map<IEnumerable<TipoInstituicaoDTO>>(tipoInstituicao);
    }

    public async Task<TipoInstituicaoDTO> BuscarPorId(int id)
    {
        var tipoInstituicao = await _tipoInstituicaoRepositorio.BuscarPorId(id);
        return _mapper.Map<TipoInstituicaoDTO>(tipoInstituicao);
    }

    public async Task Adicionar(TipoInstituicaoDTO tipoInstituicaoDTO)
    {
        var tipoInstituicao = _mapper.Map<TipoInstituicaoModel>(tipoInstituicaoDTO);
        await _tipoInstituicaoRepositorio.Adicionar(tipoInstituicao);
        tipoInstituicaoDTO.Id = tipoInstituicao.Id;
    }

    public async Task Atualizar(TipoInstituicaoDTO tipoInstituicaoDTO)
    {
        var tipoInstituicao = _mapper.Map<TipoInstituicaoModel>(tipoInstituicaoDTO);
        await _tipoInstituicaoRepositorio.Atualizar(tipoInstituicao);
    }

    public async Task Apagar(int id)
    {
        await _tipoInstituicaoRepositorio.Apagar(id);
    }
}