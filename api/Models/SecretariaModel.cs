using api.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models;

[Table("secretaria")]

public class SecretariaModel
{

    [Key]
    [Column("secretariaid")]
    public int Id { get; set; }

    /*Código para receber enum de Situação*/
    [Column("situcao")]
    [EnumDataType(typeof(EnumSituacaoModel))]
    public EnumSituacaoModel Situacao { get; set; }

    [Column("descricao")]
    public string Descricao { get; set; }

    [Column("cnpj")]
    public string CNPJ { get; set; }

    [Column("nome")]
    public string Nome { get; set; }

    [Column("logradouro")]
    public string Logradouro { get; set; }

    [Column("numero")]
    public string Numero { get; set; }

    [Column("bairro")]
    public string Bairro { get; set; }

    [Column("cep")]
    public string CEP { get; set; }

    [Column("nomerazaosocial")]
    public string NomeRazaoSocial { get; set; }

    [Column("telefone")]
    public string Telefone { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("cidade")]
    public string Cidade { get; set; }

    [Column("estado")]
    public string Estado { get; set; }

    /*Código para receber chaves estrangeiras de instituição*/
    [JsonIgnore]
    public ICollection<InstituicaoModel>? InstituicaoLista { get; set; }
}
