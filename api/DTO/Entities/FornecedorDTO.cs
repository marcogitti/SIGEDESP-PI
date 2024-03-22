using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class FornecedorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome Fantasia do Fornecedor é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "A Situação é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Situacao { get; set; }

    }
}

