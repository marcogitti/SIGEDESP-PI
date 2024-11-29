using api.Models.Enum;

namespace api.DTO.Entities
{
    public class UnidadeConsumidoraParametroDTO
    {
        public int? Id { get; set; }
        public string CodigoUC { get; set; }

        public FornecedorParametros Fornecedor { get; set; }
        public InstituicoesParametros Instituicao { get; set;}
    }

    public class FornecedorParametros
    {
        public int Id { get; set; }
        public string? NomeFantasia { get; set; }
    }

    public class InstituicoesParametros
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}
