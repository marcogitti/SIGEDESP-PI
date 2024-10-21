using api.Models.Enum; // Certifique-se de que o namespace do enum está correto
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models
{
    [Table("usuario")]
    public class UsuarioModel
    {
        [Key]
        [Column("usuarioid")]
        public int Id { get; set; }

        [Column("cpf")]
        public string CPF { get; set; }

        [Column("rg")]
        public string RG { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("cep")]
        public string CEP { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        /*Código para receber enum de Situação*/
        [Column("situcao")]
        [EnumDataType(typeof(EnumSituacaoModel))]
        public EnumSituacaoModel Situacao { get; set; }

        [Column("matricula")]
        public string Matricula { get; set; }

        [Column("tipousuario")]
        [EnumDataType(typeof(TipoUsuarioEnum))]
        public TipoUsuarioEnum TipoUsuario { get; set; }

        // Relacionamento com DespesaModel
        [JsonIgnore]
        public ICollection<DespesaModel>? Despesa { get; set; }
    }
}
