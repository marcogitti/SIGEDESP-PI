using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;

namespace api.Services.Entities;
public class DespesaService : IDespesaService
{

    private readonly IDespesaRepositorio _despesaRepositorio;
    private readonly IMapper _mapper;

    public DespesaService(IDespesaRepositorio despesaRepositorio, IMapper mapper)
    {
        _despesaRepositorio = despesaRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DespesaDTO>> BuscarTodosDespesa()
    {
        var despesa = await _despesaRepositorio.BuscarTodosDespesa();
        return _mapper.Map<IEnumerable<DespesaDTO>>(despesa);
    }

    public async Task<DespesaDTO> BuscarPorId(int id)
    {
        var despesa = await _despesaRepositorio.BuscarPorId(id);
        return _mapper.Map<DespesaDTO>(despesa);
    }

    public async Task Adicionar(DespesaDTO despesaDTO)
    {
        var despesa = _mapper.Map<DespesaModel>(despesaDTO);
        await _despesaRepositorio.Adicionar(despesa);
        despesaDTO.Id = despesa.Id;
    }

    public async Task Atualizar(DespesaDTO despesaDTO)
    {
        var despesa = _mapper.Map<DespesaModel>(despesaDTO);
        await _despesaRepositorio.Atualizar(despesa);
    }

    public async Task Apagar(int id)
    {
        await _despesaRepositorio.Apagar(id);
    }
}