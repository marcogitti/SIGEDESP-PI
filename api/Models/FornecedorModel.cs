using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models;

[Table("fornecedor")]

public class FornecedorModel
{

    [Key]
    [Column("fornecedorid")]
    public int Id { get; set; }

    [Column("nomefantasia")]
    public string NomeFantasia { get; set; }

    [Column("situacao")]
    public string Situacao { get; set; }

    /*Código para criar coleção de UnidadeConsumidora*/
    [JsonIgnore]
    public ICollection<UnidadeConsumidoraModel>? UnidadeConsumidora { get; set; }
}
