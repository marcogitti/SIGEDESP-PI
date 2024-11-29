using api.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static api.DTO.Entities.ObjetosSimplificados;

namespace api.DTO.Entities
{
    public class OrcamentoDTO
    {
        public int? Id { get; set; }
        public int AnoOrcamento { get; set; }
        public double ValorOrcamento { get; set; }


        // Subobjetos simplificados
        public InstituicaoDTO Instituicao { get; set; }
        public TipoDespesaDTO TipoDespesa { get; set; }
        public DTOInstituicao DTOInstituicao { get; set; }
        public DTOTipoDespesa DTOTipoDespesa { get; set; }
    }
}
