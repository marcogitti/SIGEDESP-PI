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

    /*Código para receber chave estrangeira de fornecedor*/
    [JsonIgnore]
    public FornecedorModel? Fornecedor { get; set; }

    [Column("fornecedorid")]
    [ForeignKey("fornecedorid")]
    public int IdFornecedor { get; set; }

    /*Código para receber chave estrangeira de Insituicao*/
    [JsonIgnore]
    public InstituicaoModel? Instituicao { get; set; }

    [Column("instituicaoid")]
    [ForeignKey("instituicaoid")]
    public int IdInstituicao { get; set; }
}