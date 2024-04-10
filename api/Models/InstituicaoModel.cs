using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("instituicao")]

public class InstituicaoModel
{

    [Key]
    [Column("instituicaoid")]
    public int Id { get; set; }

    [Column("situacao")]
    public string Situacao { get; set; }
}
