using api.Models.Enum;

namespace api.DTO.Entities
{
    public class OrcamentoParametroDTO
    {
        public int Id { get; set; }
        public int AnoOrcamento { get; set; }
        public double ValorOrcamento { get; set; }

        public InstituicoesParametro Instituicao { get; set; }
        public TipoDespesaParametros TipoDespesa { get; set; }
    }

    public class InstituicoesParametro
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }

    public class TipoDespesaParametros
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
    }

}
