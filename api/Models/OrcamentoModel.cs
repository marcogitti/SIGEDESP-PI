using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models;

[Table("orcamento")]

public class OrcamentoModel
{

    [Key]
    [Column("orcamentoid")]
    public int Id { get; set; }

    [Column("anoorcamento")]
    public int AnoOrcamento { get; set; }

    [Column("valororcamento")]
    public double ValorOrcamento { get; set; }

    /*Código para receber chaves estrangeiras de tipoDespesa e insituição*/
    [JsonIgnore]
    public TipoDespesaModel? TipoDespesa { get; set; }

    [Column("tipodespesaid")]
    [ForeignKey("tipodespesaid")]
    public int IdTipoDespesa { get; set; }

    [JsonIgnore]
    public InstituicaoModel? Instituicao { get; set; }

    [Column("instituicaoid")]
    [ForeignKey("instituicaoid")]
    public int IdInstituicao { get; set; }
}
