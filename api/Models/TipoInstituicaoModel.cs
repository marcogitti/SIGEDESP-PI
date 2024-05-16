using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models;

[Table("tipoinstituicao")]

public class TipoInstituicaoModel
{

    [Key]
    [Column("tipoinstituicaoid")]
    public int Id { get; set; }

    [Column("tipoinstituicao")]
    public string TipoInstituicao { get; set; }

    [JsonIgnore]
    public ICollection<TipoInstituicaoModel>? tipoInstituicao { get; set; }
}