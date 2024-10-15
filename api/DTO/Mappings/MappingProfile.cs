using AutoMapper;
using api.DTO.Entities;
using api.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TipoInstituicaoDTO, TipoInstituicaoModel>().ReverseMap();
        CreateMap<UnidadeMedidaDTO, UnidadeMedidaModel>().ReverseMap();
        CreateMap<SecretariaDTO, SecretariaModel>().ReverseMap();
        CreateMap<FornecedorDTO, FornecedorModel>().ReverseMap();
        CreateMap<InstituicaoDTO, InstituicaoModel>().ReverseMap();
        CreateMap<UsuarioDTO, UsuarioModel>().ReverseMap();


        //DESPESA
        CreateMap<DespesaModel, DespesaDTO>()
            .ForMember(dest => dest.Fornecedor, opt => opt.MapFrom(src => new FornecedorDTO
            {
                Id = src.Fornecedor.Id,
                NomeFantasia = src.Fornecedor.NomeFantasia
            }))
            .ForMember(dest => dest.UnidadeConsumidora, opt => opt.MapFrom(src => new UnidadeConsumidoraDTO
            {
                Id = src.UnidadeConsumidora.Id,
                CodigoUC = src.UnidadeConsumidora.CodigoUC
            }))
            .ForMember(dest => dest.Instituicao, opt => opt.MapFrom(src => new InstituicaoDTO
            {
                Id = src.Instituicao.Id,
                Nome = src.Instituicao.Nome
            }))
            .ForMember(dest => dest.Orcamento, opt => opt.MapFrom(src => new OrcamentoDTO
            {
                Id = src.Orcamento.Id,
                ValorOrcamento = src.Orcamento.ValorOrcamento
            }))
            .ForMember(dest => dest.TipoDespesa, opt => opt.MapFrom(src => new TipoDespesaDTO
            {
                Id = src.TipoDespesa.Id,
                Descricao = src.TipoDespesa.Descricao
            }))
            .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => new UsuarioDTO
            {
                Id = src.Usuario.Id,
                Nome = src.Usuario.Nome
            }));

        CreateMap<DespesaAdicionarAtualizarDTO, DespesaModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignorar o campo Id na operação de atualização


        //UNIDADE CONSUMIDORA
        CreateMap<DespesaModel, DespesaDTO>()
            .ForMember(dest => dest.Fornecedor, opt => opt.MapFrom(src => new FornecedorDTO
            {
                Id = src.Fornecedor.Id,
                NomeFantasia = src.Fornecedor.NomeFantasia
            }))
            .ForMember(dest => dest.Instituicao, opt => opt.MapFrom(src => new InstituicaoDTO
            {
                Id = src.Instituicao.Id,
                Nome = src.Instituicao.Nome
            }));

        CreateMap<UnidadeConsumidoraAdicionarAtualizarDTO, UnidadeConsumidoraModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignorar o campo Id na operação de atualização


        //INSTITUIÇÃO
        CreateMap<InstituicaoModel, InstituicaoDTO>()
            .ForMember(dest => dest.TipoInstituicao, opt => opt.MapFrom(src => new TipoInstituicaoDTO
            {
                Id = src.TipoInstituicao.Id,
                Descricao = src.TipoInstituicao.Descricao
            }))
            .ForMember(dest => dest.Secretaria, opt => opt.MapFrom(src => new SecretariaDTO
            {
                Id = src.Secretaria.Id,
                Nome = src.Secretaria.Nome
            }));

        CreateMap<InstituicaoAdicionarAtualizarDTO, InstituicaoModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignorar o campo Id na operação de atualização


        //ORÇAMENTO
        CreateMap<OrcamentoModel, OrcamentoDTO>()
            .ForMember(dest => dest.Instituicao, opt => opt.MapFrom(src => new InstituicaoDTO
            {
                Id = src.Instituicao.Id,
                Nome = src.Instituicao.Nome
            }))
            .ForMember(dest => dest.TipoDespesa, opt => opt.MapFrom(src => new TipoDespesaDTO
            {
                Id = src.TipoDespesa.Id,
                Descricao = src.TipoDespesa.Descricao
            }));

        CreateMap<OrcamentoAdicionarAtualizarDTO, OrcamentoModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignorar o campo Id na operação de atualização


        //TIPO DESPESA
        CreateMap<TipoDespesaModel, TipoDespesaDTO>()
            .ForMember(dest => dest.UnidadeMedida, opt => opt.MapFrom(src => new UnidadeMedidaDTO
            {
                Id = src.UnidadeMedida.Id,
                Descricao = src.UnidadeMedida.Descricao
            }));

        CreateMap<TipoDespesaAdicionarAtualizarDTO, TipoDespesaModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignorar o campo Id na operação de atualização
    }
}
