﻿using AutoMapper;
using wca.reembolso.application.Features.Solicitacoes.Commands;
using wca.reembolso.domain.Entities;

namespace wca.reembolso.application.Features.Solicitacoes.Common
{
    public sealed class SolicitacoProfile : Profile
    {
        public SolicitacoProfile()
        {
            CreateMap<Solicitacao, SolicitacaoResponse>();
            CreateMap<Solicitacao, SolicitacaoToPaginateResponse>()
                .ForMember(dest =>  dest.DataMenorDespesa, src=> src.MapFrom(x =>  x.Despesa.Min(y=> y.DataEvento)))
                .ForMember(dest => dest.DataMaiorDespesa, src => src.MapFrom(x => x.Despesa.Max(y => y.DataEvento)))
                .ForMember(dest => dest.ValorFaturavelCliente, src => src.MapFrom(x => x.Despesa.Where(q => q.TipoDespesa.FaturarCliente).Sum(y => y.Valor)))
                .ForMember(dest => dest.ValorReembolsoColaborador, src => src.MapFrom(x => x.Despesa.Where(q => q.TipoDespesa.ReembolsarColaborador).Sum(y => y.Valor)))
                ;


            CreateMap<SolicitacaoResponse, Solicitacao>()
                .ForMember(src => src.Colaborador, dest => dest.Ignore())
                .ForMember(src => src.CentroCusto, dest => dest.Ignore())
                .ForMember(src => src.Cliente, dest => dest.Ignore());
            CreateMap<SolicitacaoCreateCommand, Solicitacao>();
            CreateMap<SolicitacaoUpdateCommand, Solicitacao>();
            CreateMap<Despesa, DespesaResponse>()
                .ForMember(dest =>  dest.FaturarCliente, src =>  src.MapFrom(x =>  x.TipoDespesa.FaturarCliente))
                .ForMember(dest =>  dest.ReembolsarColaborador, src =>  src.MapFrom(x =>  x.TipoDespesa.ReembolsarColaborador))
                .ForMember(dest =>  dest.TipoDespesaNome, src =>  src.MapFrom(x =>  x.TipoDespesa.Nome)).ReverseMap();
        }
    }
}
