﻿using api.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class SecretariaDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "A Situação da Secretaria é requerida!")]
        public EnumSituacaoModel Situacao { get; set; }

        [Required(ErrorMessage = "A Descrição é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O CNPJ é requerido!")]
        [MinLength(14)]
        [MaxLength(14)]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O Nome é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Logradouro é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Número é requerido!")]
        [MinLength(1)]
        [MaxLength(15)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O Bairro é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O CEP é requerido!")]
        [MinLength(8)]
        [MaxLength(8)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O Nome de Razão Social é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string NomeRazaoSocial { get; set; }

        [Required(ErrorMessage = "O Telefone é requerido!")]
        [MinLength(11)]
        [MaxLength(11)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O E-mail é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Cidade é requerida!")]
        [MinLength(1)]
        [MaxLength(25)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é requerido!")]
        [MinLength(1)]
        [MaxLength(25)]
        public string Estado { get; set; }

    }
}
