using api.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models;

[Table("usuario")]

public class UsuarioModel
{

    [Key]
    [Column("usuarioid")]
    public int Id { get; set; }

    [Column("cpfcnpj")]
    public string Cpf { get; set; }

    [Column("rg")]
    public string Rg {  get; set; }

    [Column("logradouro")]
    public string Logradouro { get; set; }

    [Column("numero")]
    public string Numero {  get; set; }

    [Column("cidade")]
    public string Cidade { get; set; }

    [Column("estado")]
    public string Estado { get; set; }

    [Column("cep")]
    public string Cep { get; set; }

    [Column("bairro")]
    public string Bairro { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("senha")]
    public string Senha { get; set; }

    [Column("situacao")]
    public SituacaoEnum Situacao { get; set; }

    [Column("matricula")]
    public string Matricula { get; set; }

    [Column("nome")]
    public string Nome { get; set; }
}
