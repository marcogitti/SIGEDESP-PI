using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

    [JsonIgnore]
    public ICollection<InstituicaoModel>? InstituicaoLista { get; set; }
}
