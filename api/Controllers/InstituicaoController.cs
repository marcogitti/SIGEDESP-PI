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
    public async Task<ActionResult<IEnumerable<InstituicaoParametroDTO>>> BuscarTodosDespesa()
    {
        var instituicoes = await _context.Instituicao
            .Select(i => new InstituicaoParametroDTO
            {
                Id = i.Id,
                CNPJ = i.CNPJ,
                Nome = i.Nome,
                Logradouro = i.Logradouro,
                Numero = i.Numero,
                Bairro = i.Bairro,
                CEP = i.CEP,
                NomeRazaoSocial = i.NomeRazaoSocial,
                Telefone = i.Telefone,
                Email = i.Email,
                Cidade = i.Cidade,
                Estado = i.Estado,
                Situacao = i.Situacao,
                TipoInstituicao = new TipoInstituicaoParametro
                {
                    Id = i.TipoInstituicao.Id,
                    Descricao = i.TipoInstituicao.Descricao
                },
                Secretaria = new SecretariaParametro
                {
                    Id = i.Secretaria.Id,
                    Nome = i.Secretaria.Nome
                }
            })
            .ToListAsync();

        return Ok(instituicoes);
    }

    // Método para buscar instituição por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<InstituicaoParametroDTO>> BuscarPorId(int id)
    {
        var instituicao = await _context.Instituicao
            .Where(i => i.Id == id)
            .Select(i => new InstituicaoParametroDTO
            {
                Id = i.Id,
                CNPJ = i.CNPJ,
                Nome = i.Nome,
                Logradouro = i.Logradouro,
                Numero = i.Numero,
                Bairro = i.Bairro,
                CEP = i.CEP,
                NomeRazaoSocial = i.NomeRazaoSocial,
                Telefone = i.Telefone,
                Email = i.Email,
                Cidade = i.Cidade,
                Estado = i.Estado,
                Situacao = i.Situacao,
                TipoInstituicao = new TipoInstituicaoParametro
                {
                    Id = i.TipoInstituicao.Id,
                    Descricao = i.TipoInstituicao.Descricao
                },
                Secretaria = new SecretariaParametro
                {
                    Id = i.Secretaria.Id,
                    Nome = i.Secretaria.Nome
                }
            })
            .FirstOrDefaultAsync();

        if (instituicao == null)
            return NotFound("Instituição não encontrada");

        return Ok(instituicao);
    }

    // Método para adicionar nova instituição
    [HttpPost]
    public async Task<ActionResult<InstituicaoParametroDTO>> Cadastrar([FromBody] InstituicaoParametroDTO instituicaoDto)
    {
        if (instituicaoDto == null)
            return BadRequest("Dados inválidos");

        var novaInstituicao = new InstituicaoModel
        {
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
            Estado = instituicaoDto.Estado,
            Situacao = instituicaoDto.Situacao,
            IdTipoInstituicao = instituicaoDto.TipoInstituicao.Id,
            IdSecretaria = instituicaoDto.Secretaria.Id
        };

        _context.Instituicao.Add(novaInstituicao);
        await _context.SaveChangesAsync();

        // Carregar a instituição cadastrada com entidades relacionadas
        var instituicaoCadastrada = await _context.Instituicao
            .Include(i => i.TipoInstituicao)
            .Include(i => i.Secretaria)
            .FirstOrDefaultAsync(i => i.Id == novaInstituicao.Id);

        if (instituicaoCadastrada == null)
            return NotFound();

        var instituicaoDados = new InstituicaoParametroDTO
        {
            Id = instituicaoCadastrada.Id,
            CNPJ = instituicaoCadastrada.CNPJ,
            Nome = instituicaoCadastrada.Nome,
            Logradouro = instituicaoCadastrada.Logradouro,
            Numero = instituicaoCadastrada.Numero,
            Bairro = instituicaoCadastrada.Bairro,
            CEP = instituicaoCadastrada.CEP,
            NomeRazaoSocial = instituicaoCadastrada.NomeRazaoSocial,
            Telefone = instituicaoCadastrada.Telefone,
            Email = instituicaoCadastrada.Email,
            Cidade = instituicaoCadastrada.Cidade,
            Estado = instituicaoCadastrada.Estado,
            Situacao = instituicaoCadastrada.Situacao,
            TipoInstituicao = new TipoInstituicaoParametro
            {
                Id = instituicaoCadastrada.TipoInstituicao.Id,
                Descricao = instituicaoCadastrada.TipoInstituicao.Descricao
            },
            Secretaria = new SecretariaParametro
            {
                Id = instituicaoCadastrada.Secretaria.Id,
                Nome = instituicaoCadastrada.Secretaria.Nome
            }
        };

        return Ok(instituicaoDados);
    }

    // Método para atualizar instituicao existente
    [HttpPut]
    public async Task<ActionResult<InstituicaoParametroDTO>> Atualizar([FromBody] InstituicaoParametroDTO instituicaoDto)
    {
        if (instituicaoDto == null || instituicaoDto.Id == 0)
            return BadRequest("Dados inválidos");

        var instituicaoExistente = await _context.Instituicao.FindAsync(instituicaoDto.Id);

        if (instituicaoExistente == null)
            return NotFound("Instituição não encontrada");

        // Atualização dos atributos da instituição existente
        instituicaoExistente.CNPJ = instituicaoDto.CNPJ;
        instituicaoExistente.Nome = instituicaoDto.Nome;
        instituicaoExistente.Logradouro = instituicaoDto.Logradouro;
        instituicaoExistente.Numero = instituicaoDto.Numero;
        instituicaoExistente.Bairro = instituicaoDto.Bairro;
        instituicaoExistente.CEP = instituicaoDto.CEP;
        instituicaoExistente.NomeRazaoSocial = instituicaoDto.NomeRazaoSocial;
        instituicaoExistente.Telefone = instituicaoDto.Telefone;
        instituicaoExistente.Email = instituicaoDto.Email;
        instituicaoExistente.Cidade = instituicaoDto.Cidade;
        instituicaoExistente.Estado = instituicaoDto.Estado;
        instituicaoExistente.Situacao = instituicaoDto.Situacao;

        // Atualização de subobjetos
        instituicaoExistente.IdTipoInstituicao = instituicaoDto.TipoInstituicao.Id;
        instituicaoExistente.IdSecretaria = instituicaoDto.Secretaria.Id;

        await _context.SaveChangesAsync();

        // Carregar a instituição cadastrada com entidades relacionadas
        var instituicaoAtualizada = await _context.Instituicao
            .Include(i => i.TipoInstituicao)
            .Include(i => i.Secretaria)
            .FirstOrDefaultAsync(i => i.Id == instituicaoExistente.Id);

        // Criar DTO com os dados atualizados
        var instituicaoDados = new InstituicaoParametroDTO
        {
            Id = instituicaoAtualizada.Id,
            CNPJ = instituicaoAtualizada.CNPJ,
            Nome = instituicaoAtualizada.Nome,
            Logradouro = instituicaoAtualizada.Logradouro,
            Numero = instituicaoAtualizada.Numero,
            Bairro = instituicaoAtualizada.Bairro,
            CEP = instituicaoAtualizada.CEP,
            NomeRazaoSocial = instituicaoAtualizada.NomeRazaoSocial,
            Telefone = instituicaoAtualizada.Telefone,
            Email = instituicaoAtualizada.Email,
            Cidade = instituicaoAtualizada.Cidade,
            Estado = instituicaoAtualizada.Estado,
            Situacao = instituicaoAtualizada.Situacao,
            TipoInstituicao = new TipoInstituicaoParametro
            {
                Id = instituicaoAtualizada.TipoInstituicao.Id,
                Descricao = instituicaoAtualizada.TipoInstituicao.Descricao
            },
            Secretaria = new SecretariaParametro
            {
                Id = instituicaoAtualizada.Secretaria.Id,
                Nome = instituicaoAtualizada.Secretaria.Nome
            }
        };

        return Ok(instituicaoDados);
    }

    // Método para excluir instituição
    [HttpDelete("{id}")]
    public async Task<IActionResult> Apagar(int id)
    {
        var instituicao = await _context.Instituicao.FindAsync(id);

        if (instituicao == null)
            return NotFound("Instituição não encontrada");

        _context.Instituicao.Remove(instituicao);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
