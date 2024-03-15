using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("secretaria")]

public class SecretariaModel
{

    [Key]
    [Column("secretariaid")]
    public int Id { get; set; }

    [Column("situacao")]
    public string Situacao { get; set; }

    [Column("descricao")]
    public string Descricao { get; set; }
}
