using api.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models;

[Table("fornecedor")]

public class FornecedorModel
{

    [Key]
    [Column("fornecedorid")]
    public int Id { get; set; }

    [Column("nomefantasia")]
    public string NomeFantasia { get; set; }

    /*Código para receber enum de Situação*/
    [Column("situcao")]
    [EnumDataType(typeof(EnumSituacaoModel))]
    public EnumSituacaoModel Situacao { get; set; }

    [Column("cnpj")]
    public string Cnpj { get; set; }

    [Column("nome")]
    public string Nome { get; set; }

    [Column("logradouro")]
    public string Logradouro { get; set; }

    [Column("numero")]
    public string Numero { get; set; }

    [Column("bairro")]
    public string Bairro { get; set; }

    [Column("cep")]
    public string Cep { get; set; }

    [Column("telefone")]
    public string Telefone { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("cidade")]
    public string Cidade { get; set; }

    [Column("estado")]
    public string Estado { get; set; }

    /*Código para criar coleção de UnidadeConsumidora*/
    [JsonIgnore]
    public ICollection<UnidadeConsumidoraModel>? UnidadeConsumidora { get; set; }

    /*Código para criar coleção de Despesa*/
    [JsonIgnore]
    public ICollection<DespesaModel>? Despesa { get; set; }
}
