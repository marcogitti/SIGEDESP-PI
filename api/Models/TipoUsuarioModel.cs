using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("tipousuario")]

public class TipoUsuarioModel
{

    [Key]
    [Column("tipousuarioid")]
    public int Id { get; set; }

    [Column("descricao")]
    public string Descricao { get; set; }

    [Column("permitelogin")]
    public string PermiteLogin { get; set; }
}
