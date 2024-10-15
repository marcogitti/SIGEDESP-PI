using System.ComponentModel.DataAnnotations;

namespace api.DTO.Entities
{
    public class UnidadeConsumidoraAdicionarAtualizarDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O Número do Documento é requerido!")]
        public string CodigoUC { get; set; }

        [Required(ErrorMessage = "O ID de Instituição é requerido!")]
        public int IdInstituicao { get; set; }

        [Required(ErrorMessage = "O ID de Fornecedor é requerido!")]
        public int IdFornecedor { get; set; }
    }
}
