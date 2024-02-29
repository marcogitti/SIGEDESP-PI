using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;

namespace api.Services.Entities;
public class TipoDespesaService : ITipoDespesaService
{

    private readonly ITipoDespesaRepositorio _tipoDespesaRepositorio;
    private readonly IMapper _mapper;

    public TipoDespesaService(ITipoDespesaRepositorio tipoDespesaRepositorio, IMapper mapper)
    {
        _tipoDespesaRepositorio = tipoDespesaRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TipoDespesaDTO>> BuscarTodosTipoDespesa()
    {
        var tipoDespesa = await _tipoDespesaRepositorio.BuscarTodosTipoDespesa();
        return _mapper.Map<IEnumerable<TipoDespesaDTO>>(tipoDespesa);
    }

    public async Task<TipoDespesaDTO> BuscarPorId(int id)
    {
        var tipoDespesa = await _tipoDespesaRepositorio.BuscarPorId(id);
        return _mapper.Map<TipoDespesaDTO>(tipoDespesa);
    }

    public async Task Adicionar(TipoDespesaDTO tipoDespesaDTO)
    {
        var tipoDespesa = _mapper.Map<TipoDespesaModel>(tipoDespesaDTO);
        await _tipoDespesaRepositorio.Adicionar(tipoDespesa);
        tipoDespesaDTO.Id = tipoDespesa.Id;
    }

    public async Task Atualizar(TipoDespesaDTO tipoDespesaDTO)
    {
        var tipoDespesa = _mapper.Map<TipoDespesaModel>(tipoDespesaDTO);
        await _tipoDespesaRepositorio.Atualizar(tipoDespesa);
    }

    public async Task Apagar(int id)
    {
        await _tipoDespesaRepositorio.Apagar(id);
    }
}