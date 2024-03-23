using api.DTO.Entities;
using api.Service.Interfaces;
using AutoMapper;
using api.Repositorios.Interfaces;
using api.Models;

namespace api.Services.Entities;
public class FornecedorService : IFornecedorService
{

    private readonly IFornecedorRepositorio _fornecedorRepositorio;
    private readonly IMapper _mapper;

    public FornecedorService(IFornecedorRepositorio fornecedorRepositorio, IMapper mapper)
    {
        _fornecedorRepositorio = fornecedorRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FornecedorDTO>> BuscarTodosFornecedor()
    {
        var fornecedor = await _fornecedorRepositorio.BuscarTodosFornecedor();
        return _mapper.Map<IEnumerable<FornecedorDTO>>(fornecedor);
    }

    public async Task<FornecedorDTO> BuscarPorId(int id)
    {
        var fornecedor = await _fornecedorRepositorio.BuscarPorId(id);
        return _mapper.Map<FornecedorDTO>(fornecedor);
    }

    public async Task Adicionar(FornecedorDTO fornecedorDTO)
    {
        var fornecedor = _mapper.Map<FornecedorModel>(fornecedorDTO);
        await _fornecedorRepositorio.Adicionar(fornecedor);
        fornecedorDTO.Id = fornecedor.Id;
    }

    public async Task Atualizar(FornecedorDTO fornecedorDTO)
    {
        var fornecedor = _mapper.Map<FornecedorModel>(fornecedorDTO);
        await _fornecedorRepositorio.Atualizar(fornecedor);
    }

    public async Task Apagar(int id)
    {
        await _fornecedorRepositorio.Apagar(id);
    }
}