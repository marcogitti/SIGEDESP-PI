using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;
using api.Repositorios;

namespace api.Services.Entities;
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
        var orcamento = await _orcamentoRepositorio.BuscarTodosOrcamento();
        return _mapper.Map<IEnumerable<OrcamentoDTO>>(orcamento);
    }

    public async Task<OrcamentoDTO> BuscarPorId(int id)
    {
        var orcamento = await _orcamentoRepositorio.BuscarPorId(id);
        return _mapper.Map<OrcamentoDTO>(orcamento);
    }

    public async Task Adicionar(OrcamentoDTO orcamentoDTO)
    {
        var orcamento = _mapper.Map<OrcamentoModel>(orcamentoDTO);
        await _orcamentoRepositorio.Adicionar(orcamento);
        orcamentoDTO.Id = orcamento.Id;
    }

    public async Task Atualizar(OrcamentoDTO orcamentoDTO)
    {
        var orcamento = _mapper.Map<OrcamentoModel>(orcamentoDTO);
        await _orcamentoRepositorio.Atualizar(orcamento);
    }

    public async Task Apagar(int id)
    {
        await _orcamentoRepositorio.Apagar(id);
    }
}