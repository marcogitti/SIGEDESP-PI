using api.Data;
using api.DTO.Entities;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/unidade/consumidora")]
public class UnidadeConsumidoraController : ControllerBase
{
    private readonly SigedespDBContex _context;

    public UnidadeConsumidoraController(SigedespDBContex context)
    {
        _context = context;
    }

    // Método para buscar todas as unidades consumidoras
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UnidadeConsumidoraParametroDTO>>> BuscarTodosDespesa()
    {
        var unidadesconsumidoras = await _context.UnidadeConsumidora
            .Select(uc => new UnidadeConsumidoraParametroDTO
            {
                Id = uc.Id,
                CodigoUC = uc.CodigoUC,
                Fornecedor = new FornecedorParametros
                {
                    Id = uc.Fornecedor.Id,
                    NomeFantasia = uc.Fornecedor.NomeFantasia
                },
                Instituicao = new InstituicoesParametros
                {
                    Id = uc.Instituicao.Id,
                    Nome = uc.Instituicao.Nome
                }
            })
            .ToListAsync();

        return Ok(unidadesconsumidoras);
    }

    // Método para buscar unidades consumidoras por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<UnidadeConsumidoraParametroDTO>> BuscarPorId(int id)
    {
        var unidadeconsumidora = await _context.UnidadeConsumidora
            .Where(uc => uc.Id == id)
            .Select(uc => new UnidadeConsumidoraParametroDTO
            {
                Id = uc.Id,
                CodigoUC = uc.CodigoUC,
                Fornecedor = new FornecedorParametros
                { 
                    Id = uc.Fornecedor.Id,
                    NomeFantasia = uc.Fornecedor.NomeFantasia
                },
                Instituicao = new InstituicoesParametros
                {
                    Id = uc.Instituicao.Id,
                    Nome = uc.Instituicao.Nome
                }
            })
            .FirstOrDefaultAsync();

        if (unidadeconsumidora == null)
            return NotFound("Unidade Consumidora não encontrada");

        return Ok(unidadeconsumidora);
    }

    // Método para adicionar nova unidade consumidora
    [HttpPost]
    public async Task<ActionResult<UnidadeConsumidoraParametroDTO>> Cadastrar([FromBody] UnidadeConsumidoraParametroDTO unidadeconsumidoraDto)
    {
        if (unidadeconsumidoraDto == null)
            return BadRequest("Dados inválidos");

        var novaUnidadeConsumidora = new UnidadeConsumidoraModel
        {
            CodigoUC = unidadeconsumidoraDto.CodigoUC,
            IdFornecedor = unidadeconsumidoraDto.Fornecedor.Id,
            IdInstituicao = unidadeconsumidoraDto.Instituicao.Id,
        };

        _context.UnidadeConsumidora.Add(novaUnidadeConsumidora);
        await _context.SaveChangesAsync();

        // Carregar a unidade consumidora cadastrada com entidades relacionadas
        var unidadeconsumidoraCadastrada = await _context.UnidadeConsumidora
            .Include(uc => uc.Fornecedor)
            .Include(uc => uc.Instituicao)
            .FirstOrDefaultAsync(uc => uc.Id == novaUnidadeConsumidora.Id);

        if (unidadeconsumidoraCadastrada == null)
            return NotFound();

        var unidadeconsumidoraDados = new UnidadeConsumidoraParametroDTO
        {
            Id = unidadeconsumidoraCadastrada.Id,
            CodigoUC = unidadeconsumidoraCadastrada.CodigoUC,
            Fornecedor = new FornecedorParametros
            {
                Id = unidadeconsumidoraCadastrada.Fornecedor.Id,
                NomeFantasia = unidadeconsumidoraCadastrada.Fornecedor.NomeFantasia
            },
            Instituicao = new InstituicoesParametros
            {
                Id = unidadeconsumidoraCadastrada.Instituicao.Id,
                Nome = unidadeconsumidoraCadastrada.Instituicao.Nome
            }
        };

        return Ok(unidadeconsumidoraDados);
    }

    // Método para atualizar orçamento existente
    [HttpPut]
    public async Task<ActionResult<UnidadeConsumidoraParametroDTO>> Atualizar([FromBody] UnidadeConsumidoraParametroDTO unidadeconsumidoraDto)
    {
        if (unidadeconsumidoraDto == null || unidadeconsumidoraDto.Id == 0)
            return BadRequest("Dados inválidos");

        var unidadeconsumidoraExistente = await _context.UnidadeConsumidora.FindAsync(unidadeconsumidoraDto.Id);

        if (unidadeconsumidoraExistente == null)
            return NotFound("Unidade Consumidora não encontrada");

        // Atualização dos atributos da unidade consumidora existente
        unidadeconsumidoraExistente.CodigoUC = unidadeconsumidoraDto.CodigoUC;

        // Atualização de subobjetos
        unidadeconsumidoraExistente.IdFornecedor = unidadeconsumidoraDto.Fornecedor.Id;
        unidadeconsumidoraExistente.IdInstituicao = unidadeconsumidoraDto.Instituicao.Id;

        await _context.SaveChangesAsync();

        // Carregar a unidade consumidora cadastrada com entidades relacionadas
        var unidadeconsumidoraAtualizada = await _context.UnidadeConsumidora
            .Include(uc => uc.Fornecedor)
            .Include(uc => uc.Instituicao)
            .FirstOrDefaultAsync(uc => uc.Id == unidadeconsumidoraExistente.Id);

        // Criar DTO com os dados atualizados
        var unidadeconsumidoraDados = new UnidadeConsumidoraParametroDTO
        {
            Id = unidadeconsumidoraAtualizada.Id,
            CodigoUC = unidadeconsumidoraAtualizada.CodigoUC,
            Fornecedor = new FornecedorParametros
            {
                Id = unidadeconsumidoraAtualizada.Fornecedor.Id,
                NomeFantasia = unidadeconsumidoraAtualizada.Fornecedor.NomeFantasia
            },
            Instituicao = new InstituicoesParametros
            {
                Id = unidadeconsumidoraAtualizada.Instituicao.Id,
                Nome = unidadeconsumidoraAtualizada.Instituicao.Nome
            }
        };

        return Ok(unidadeconsumidoraDados);
    }

    // Método para excluir unidade consumidora
    [HttpDelete("{id}")]
    public async Task<IActionResult> Apagar(int id)
    {
        var unidadeconsumidora = await _context.UnidadeConsumidora.FindAsync(id);

        if (unidadeconsumidora == null)
            return NotFound("Unidade Consumidora não encontrada");

        _context.UnidadeConsumidora.Remove(unidadeconsumidora);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
