using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("unidadeconsumidora")]

public class UnidadeConsumidoraModel
{

    [Key]
    [Column("unidadeconsumidoraid")]
    public int Id { get; set; }

    [Column("unidadeconsumidora")]
    public int codigoUC { get; set; }
}