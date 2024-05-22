using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("tipodespesa")]

public class TipoDespesaModel
{

    [Key]
    [Column("tipodespesaid")]
    public int Id { get; set; }

    [Column("tipodespesa")]
    public string TipoDespesa { get; set; }

    [Column("solicitauc")]
    public string SolicitaUC { get; set; }

    public UnidadeMedidaModel? UnidadeMedida { get; set; }

    [Column("unidademedidaid")]
    [ForeignKey("unidademedidaid")]
    public int IdUnidadeMedida { get; set; }
}