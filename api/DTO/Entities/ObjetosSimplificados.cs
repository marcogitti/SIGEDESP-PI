namespace api.DTO.Entities
{
    public class ObjetosSimplificados
    {
        public class DTOFornecedor
        {
            public int Id { get; set; }
            public string NomeFantasia { get; set; }
        }

        public class DTOUnidadeConsumidora
        {
            public int Id { get; set; }
            public string CodigoUC { get; set; }
        }

        public class DTOInstituicao
        {
            public int Id { get; set; }
            public string Nome { get; set; }
        }

        public class DTOOrcamento
        {
            public int Id { get; set; }
            public double ValorOrcamento { get; set; }
        }

        public class DTOTipoDespesa
        {
            public int Id { get; set; }
            public string Descricao { get; set; }
        }

        public class DTOUsuario
        {
            public int Id { get; set; }
            public string Nome { get; set; }
        }

        public class DTOTipoInstituicao
        {
            public int Id { get; set; }
            public string Descricao { get; set;}
        }

        public class DTOSecretaria
        {
            public int Id { get; set; }
            public string Nome { get; set; }
        }

        public class DTOUnidadeMedida
        { 
            public int Id { get; set; }
            public string Descricao { get; set; }
        }
    }
}
