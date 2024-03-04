using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("unidademedida")]

public class UnidadeMedidaModel
{

    [Key]
    [Column("unidademedidaid")]
    public int Id { get; set; }

    [Column("descrição")]
    public string Descricao { get; set; }

    [Column("abreviatura")]
    public string Abreviatura { get; set; }
}