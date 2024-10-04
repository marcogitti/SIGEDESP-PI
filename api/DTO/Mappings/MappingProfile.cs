using AutoMapper;
using api.DTO.Entities;
using api.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<TipoDespesaDTO, TipoDespesaModel>().ReverseMap();
        CreateMap<TipoInstituicaoDTO, TipoInstituicaoModel>().ReverseMap();
        CreateMap<UnidadeMedidaDTO, UnidadeMedidaModel>().ReverseMap();
        CreateMap<UnidadeConsumidoraDTO, UnidadeConsumidoraModel>().ReverseMap();
        CreateMap<SecretariaDTO, SecretariaModel>().ReverseMap();
        CreateMap<FornecedorDTO, FornecedorModel>().ReverseMap();
        CreateMap<InstituicaoDTO, InstituicaoModel>().ReverseMap();
        CreateMap<OrcamentoDTO, OrcamentoModel>().ReverseMap();
        CreateMap<UsuarioDTO, UsuarioModel>().ReverseMap();

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

    }
}
