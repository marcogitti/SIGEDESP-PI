namespace api.DTO.Responses
{
    public class FornecedorResponseDTO
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
    }

    public class UnidadeConsumidoraResponseDTO
    {
        public int Id { get; set; }
        public string CodigoUC { get; set; }
    }

    public class InstituicaoResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class OrcamentoResponseDTO
    {
        public int Id { get; set; }
        public double ValorOrcamento { get; set; }
    }

    public class TipoDespesaResponseDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }

    public class UsuarioResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class DespesaResponseDTO
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public FornecedorResponseDTO Fornecedor { get; set; }
        public UnidadeConsumidoraResponseDTO UnidadeConsumidora { get; set; }
        public InstituicaoResponseDTO Instituicao { get; set; }
        public OrcamentoResponseDTO Orcamento { get; set; }
        public TipoDespesaResponseDTO TipoDespesa { get; set; }
        public UsuarioResponseDTO Usuario { get; set; }
    }
}
