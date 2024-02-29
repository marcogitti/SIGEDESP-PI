using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("tipoinstituicao")]

public class TipoInstituicaoModel
{

    [Key]
    [Column("tipoinstituicaoid")]
    public int Id { get; set; }

    [Column("tipoinstituicao")]
    public string TipoInstituicao { get; set; }
}