using api.DTO.Entities;
using api.Models;
using AutoMapper;

namespace api.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<TipoDespesaDTO, TipoDespesaModel>();
            CreateMap<TipoDespesaModel, TipoDespesaDTO>().ReverseMap();

            CreateMap<TipoInstituicaoDTO, TipoInstituicaoModel>();
            CreateMap<TipoInstituicaoModel, TipoInstituicaoDTO>().ReverseMap();

            CreateMap<UnidadeMedidaDTO, UnidadeMedidaModel>();
            CreateMap<UnidadeMedidaModel, UnidadeMedidaDTO>().ReverseMap();

            CreateMap<UnidadeConsumidoraDTO, UnidadeConsumidoraModel>();
            CreateMap<UnidadeConsumidoraModel, UnidadeConsumidoraDTO>().ReverseMap();

            CreateMap<SecretariaDTO, SecretariaModel>();
            CreateMap<SecretariaModel, SecretariaDTO>().ReverseMap();

            CreateMap<FornecedorDTO, FornecedorModel>();
            CreateMap<FornecedorModel, FornecedorDTO>().ReverseMap();

            CreateMap<InstituicaoDTO, InstituicaoModel>();
            CreateMap<InstituicaoModel, InstituicaoDTO>().ReverseMap();

            CreateMap<OrcamentoDTO, OrcamentoModel>();
            CreateMap<OrcamentoModel, OrcamentoDTO>().ReverseMap();

            CreateMap<UsuarioDTO, UsuarioModel>();
            CreateMap<UsuarioModel, UsuarioDTO>().ReverseMap();
        }
    }
}
