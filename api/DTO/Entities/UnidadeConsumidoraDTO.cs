using api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static api.DTO.Entities.ObjetosSimplificados;

namespace api.DTO.Entities
{
    public class UnidadeConsumidoraDTO
    {
        public int? Id { get; set; }
        public string CodigoUC { get; set; }

        // Subobjetos simplificados
        public InstituicaoDTO Instituicao { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        public DTOFornecedor DTOFornecedor { get; set; }
        public DTOInstituicao DTOInstituicao { get; set; }
    }
}