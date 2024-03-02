﻿using AutoMapper;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using wca.reembolso.application.Common;
using wca.reembolso.application.Contracts.Persistence;
using wca.reembolso.domain.Entities;

namespace wca.reembolso.application.Features.Despesas.Command
{
    public sealed record DespesaCreateCommand (
        int SolicitacaoId,
        int TipoDespesaId,
        DateTime DataEvento,
        decimal Valor,
        string? NumeroFiscal,
        string? ImagePath,
        string? RazaoSocial,
        string? CNPJ,
        string? InscricaoEstadual,
        string? Motivo,
        string? Origem,
        string? Destino,
        decimal? KmPercorrido
    ): IRequest<ErrorOr<Despesa>>;

    internal sealed class DespesaCreateCommandHandle : IRequestHandler<DespesaCreateCommand, ErrorOr<Despesa>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _rm;

        public DespesaCreateCommandHandle(IMapper mapper, IRepositoryManager rm)
        {
            _mapper = mapper;
            _rm = rm;
        }

        public async Task<ErrorOr<Despesa>> Handle(DespesaCreateCommand request, CancellationToken cancellationToken)
        {
            Despesa despesa = _mapper.Map<Despesa>(request);

            if (HandleFile.IsBase64(despesa.ImagePath))
            {
                despesa.ImagePath = HandleFile.SaveFile(despesa.ImagePath);
            }

            _rm.DespesaRepository.Create(despesa);
            
            await _rm.SaveAsync();

            return despesa;

        }
    }
}
