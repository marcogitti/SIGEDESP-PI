using api.Models.Enum;
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
    public SituacaoEnum Situacao { get; set; }

    [Column("descricao")]
    public string Descricao { get; set; }

    [Column("cnpj")]
    public string Cnpj { get; set; }

    [Column("nome")]
    public string Nome { get; set; }

    [Column("logradouro")]
    public string Logradouro { get; set; }

    [Column("numero")]
    public int Numero { get; set; }

    [Column("bairro")]
    public string Bairro { get; set; }

    [Column("rua")]
    public string Rua { get; set; }

    [Column("cep")]
    public int Cep { get; set; }

    [Column("nomerazaosocial")]
    public string nomeRazaoSocial { get; set; }

    [Column("telefone")]
    public string Telefone { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("cidade")]
    public string Cidade { get; set; }

    [Column("estado")]
    public string Estado { get; set; }

    [JsonIgnore]
    public ICollection<InstituicaoModel>? InstituicaoLista { get; set; }
}
