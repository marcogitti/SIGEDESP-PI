using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

    /*Código para criar coleção de Usuario*/
    [JsonIgnore]
    public ICollection<UsuarioModel>? Usuario { get; set; }
}
