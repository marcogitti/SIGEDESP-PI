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

    [Column("descricao")]
    public string Descricao { get; set; }

    /*Código para criar coleção de Instituição*/
    [JsonIgnore]
    public ICollection<InstituicaoModel>? InstituicaoLista { get; set; }
}