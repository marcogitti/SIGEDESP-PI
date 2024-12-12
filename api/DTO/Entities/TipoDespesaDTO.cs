using api.Models;
using api.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static api.DTO.Entities.ObjetosSimplificados;

namespace api.DTO.Entities
{
    public class TipoDespesaDTO
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public EnumSolicitaUCModel SolicitaUC { get; set; }

        // Subobjetos simplificados
        public UnidadeMedidaDTO UnidadeMedida { get; set; }
        public DTOUnidadeMedida DTOUnidadeMedida { get; set; }
    }
}
