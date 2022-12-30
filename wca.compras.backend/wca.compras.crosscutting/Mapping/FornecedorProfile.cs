﻿using AutoMapper;
using wca.compras.domain.Dtos;
using wca.compras.domain.Entities;
using wca.compras.domain.Util;

namespace wca.compras.crosscutting.Mapping
{
    public class FornecedorProfile: Profile
    {
        public FornecedorProfile()
        {
            CreateMap<Fornecedor, FornecedorDto>().ReverseMap();
            
            CreateMap<CreateFornecedorDto, Fornecedor>()
                .ForMember(src => src.FornecedorContatos, dest => dest.Ignore());
            
            CreateMap<UpdateFornecedorDto, Fornecedor>()
                .ForMember(src => src.FornecedorContatos, dest => dest.MapFrom(opt => opt.FornecedorContatos)); ;
            
            CreateMap<Fornecedor, ListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Nome));

            CreateMap<Produto, ProdutoDto>().ReverseMap();
            CreateMap<CreateProdutoDto, Produto>();
            CreateMap<UpdateProdutoDto, Produto>().ReverseMap();

            CreateMap<FornecedorContato, FornecedorContatoDto>().ReverseMap();
        }
    }
}