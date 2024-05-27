using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models;

[Table("instituicao")]

public class InstituicaoModel
{

    [Key]
    [Column("instituicaoid")]
    public int Id { get; set; }

    [Column("situacao")]
    public string Situacao { get; set; }

    /*Código para receber chaves estrangeiras de tipoInsituicao e Secretaria*/
    [JsonIgnore]
    public TipoInstituicaoModel? tipoInstituicao { get; set; }

    [Column("tipoinstituicaoid")]
    [ForeignKey("tipoinstituicaoid")]
    public int IdTipoInstituicao { get; set; }

    [JsonIgnore]
    public SecretariaModel? Secretaria { get; set; }

    [Column("secretariaid")]
    [ForeignKey("secretariaid")]
    public int IdSecretaria { get; set; }

    /*Código para criar coleção de Orçamento*/
    [JsonIgnore]
    public ICollection<OrcamentoModel>? Orcamento { get; set; }

    /*Código para criar coleção de UnidadeConsumidora*/
    [JsonIgnore]
    public ICollection<UnidadeConsumidoraModel>? UnidadeConsumidora { get; set; }
}
