using api.Data;
using api.DTO.Entities;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/instituicao")]
public class InstituicaoController : ControllerBase
{
    private readonly SigedespDBContex _context;

    public InstituicaoController(SigedespDBContex context)
    {
        _context = context;
    }

    // Método para buscar todas as instituições
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> BuscarTodosInstituicao()
    {
        var instituicoes = await _context.Instituicao
            .Select(d => new
            {
                Id = d.Id,
                Situacao = d.Situacao,
                CNPJ = d.CNPJ,
                Nome = d.Nome,
                Logradouro = d.Logradouro,
                Numero = d.Numero,
                Bairro = d.Bairro,
                CEP = d.CEP,
                NomeRazaoSocial = d.NomeRazaoSocial,
                Telefone = d.Telefone,
                Email = d.Email,
                Cidade = d.Cidade,
                Estado = d.Estado,
                TipoInstituicao = new
                {
                    Id = d.TipoInstituicao.Id,
                    Descricao = d.TipoInstituicao.Descricao
                },
                Secretaria = new
                {
                    Id = d.Secretaria.Id,
                    Nome = d.Secretaria.Nome
                }
            })
            .ToListAsync();

        return Ok(instituicoes);
    }

    // Método para buscar instituição por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<object>> BuscarPorId(int id)
    {
        var instituicao = await _context.Instituicao
            .Where(d => d.Id == id)
            .Select(d => new
            {
                Id = d.Id,
                Situacao = d.Situacao,
                CNPJ = d.CNPJ,
                Nome = d.Nome,
                Logradouro = d.Logradouro,
                Numero = d.Numero,
                Bairro = d.Bairro,
                CEP = d.CEP,
                NomeRazaoSocial = d.NomeRazaoSocial,
                Telefone = d.Telefone,
                Email = d.Email,
                Cidade = d.Cidade,
                Estado = d.Estado,
                TipoInstituicao = new
                {
                    Id = d.TipoInstituicao.Id,
                    Descricao = d.TipoInstituicao.Descricao
                },
                Secretaria = new
                {
                    Id = d.Secretaria.Id,
                    Nome = d.Secretaria.Nome
                }
            })
            .FirstOrDefaultAsync();

        if (instituicao == null)
            return NotFound("Instituição não encontrada");

        return Ok(instituicao);
    }

    // Método para adicionar nova instituição
    [HttpPost]
    public async Task<ActionResult> Cadastrar([FromBody] InstituicaoAdicionarAtualizarDTO instituicaoDto)
    {
        if (instituicaoDto == null)
            return BadRequest("Dados inválidos");

        var instituicao = new InstituicaoModel
        {
            Situacao = instituicaoDto.Situacao,
            CNPJ = instituicaoDto.CNPJ,
            Nome = instituicaoDto.Nome,
            Logradouro = instituicaoDto.Logradouro,
            Numero = instituicaoDto.Numero,
            Bairro = instituicaoDto.Bairro,
            CEP = instituicaoDto.CEP,
            NomeRazaoSocial = instituicaoDto.NomeRazaoSocial,
            Telefone = instituicaoDto.Telefone,
            Email = instituicaoDto.Email,   
            Cidade = instituicaoDto.Cidade,
            Estado = instituicaoDto.Estado
        };

        _context.Instituicao.Add(instituicao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = instituicao.Id }, instituicao);
    }

    // Método para atualizar instituição existente
    [HttpPut()]
    public async Task<ActionResult> Atualizar([FromBody] InstituicaoAdicionarAtualizarDTO instituicaoAtualizada)
    {
        if (instituicaoAtualizada == null || instituicaoAtualizada.Id != instituicaoAtualizada.Id)
            return BadRequest("Dados inválidos");

        var instituicaoExistente = await _context.Instituicao.FindAsync(instituicaoAtualizada.Id);

        if (instituicaoExistente == null)
            return NotFound("Instituição não encontrada");

        _context.Entry(instituicaoExistente).CurrentValues.SetValues(instituicaoAtualizada);
        await _context.SaveChangesAsync();

        return Ok(instituicaoAtualizada);
    }

    // Método para deletar instituição
    [HttpDelete("{id}")]
    public async Task<ActionResult<object>> Apagar(int id)
    {
        var instituicao = await _context.Instituicao.FindAsync(id);

        if (instituicao == null)
            return NotFound("Instituição não encontrada");

        _context.Instituicao.Remove(instituicao);
        await _context.SaveChangesAsync();

        var instituicaoRemovida = new InstituicaoDTO
        {
            Id = instituicao.Id,
            Situacao = instituicao.Situacao,
            CNPJ = instituicao.CNPJ,
            Nome = instituicao.Nome,
            Logradouro = instituicao.Logradouro,
            Numero = instituicao.Numero,
            Bairro = instituicao.Bairro,
            CEP = instituicao.CEP,
            NomeRazaoSocial = instituicao.NomeRazaoSocial,
            Telefone = instituicao.Telefone,
            Email = instituicao.Email,
            Cidade = instituicao.Cidade,
            Estado = instituicao.Estado,
            TipoInstituicao = new TipoInstituicaoDTO
            {
                Id = instituicao.TipoInstituicao.Id,
                Descricao = instituicao.TipoInstituicao.Descricao
            },
            Secretaria = new SecretariaDTO
            {
                Id = instituicao.Secretaria.Id,
                Nome = instituicao.Secretaria.Nome
            }
        };

        return Ok(instituicaoRemovida);
    }
}
