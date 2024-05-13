using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models;

[Table("unidadeconsumidora")]

public class UnidadeConsumidoraModel
{

    [Key]
    [Column("unidadeconsumidoraid")]
    public int Id { get; set; }

    [Column("unidadeconsumidora")]
    public int CodigoUC { get; set; }

    [JsonIgnore]
    public FornecedorModel? Fornecedor { get; set; }

    [Column("fornecedorid")]
    [ForeignKey("fornecedorid")]
    public int IdFornecedor { get; set; }
}