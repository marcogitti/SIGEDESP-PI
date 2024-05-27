using api.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class OrcamentoDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O Ano do Orçamento é requerido!")]
        public int AnoOrcamento { get; set; }

        [Required(ErrorMessage = "O Valor do Orçamento é requerido!")]
        public double ValorOrcamento { get; set; }

        /*Código para colocar atributos da classes que dão chave estrangeira no cadastro*/
        [JsonIgnore]
        public TipoDespesaModel? TipoDespesa { get; set; }

        [Required(ErrorMessage = "O ID de Tipo Despesa é requerido!")]
        public int IdTipoDespesa { get; set; }

        [JsonIgnore]
        public InstituicaoModel? Instituicao { get; set; }

        [Required(ErrorMessage = "O ID de Instituição é requerido!")]
        public int IdInstituicao { get; set; }
    }
}
