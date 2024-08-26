using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models;

[Table("tipodespesa")]

public class TipoDespesaModel
{

    [Key]
    [Column("tipodespesaid")]
    public int Id { get; set; }

    [Column("descricao")]
    public string Descricao { get; set; }

    [Column("solicitauc")]
    public string SolicitaUC { get; set; }

    /*Código para receber chave estrangeira de unidadeMedida*/
    public virtual UnidadeMedidaModel? UnidadeMedida { get; set; }

    [Column("idunidademedida")]
    [ForeignKey("unidademedidaid")]
    public int IdUnidadeMedida { get; set; }

    /*Código para criar coleção de Orçamento*/
    [JsonIgnore]
    public ICollection<OrcamentoModel>? Orcamento { get; set; }

    /*Código para criar coleção de Despesa*/
    [JsonIgnore]
    public ICollection<DespesaModel>? Despesa { get; set; }
}