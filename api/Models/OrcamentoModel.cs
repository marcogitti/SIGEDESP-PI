using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
}
