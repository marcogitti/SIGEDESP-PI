using api.Models.Enum;

namespace api.DTO.Entities
{
    public class TipoDespesaParametroDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public EnumSolicitaUCModel SolicitaUC { get; set; }

        public UnidadeMedidaParametro UnidadeMedida { get; set; }
    }

    public class UnidadeMedidaParametro
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
    }
}
