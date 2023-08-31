﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using wca.reembolso.domain.Entities;

namespace wca.reembolso.application.Features.Faturamentos.Common
{
    public sealed record FaturamentoPaginateResponse
    (
        int Id,
        int UsuarioId,
        int ClienteId,
        string ClienteNome,
        int Status,
        int Valor,
        string? NumeroPO,
        string? DocumentoPO
    );

    public sealed record FaturamentoResponse
    (
        int Id,
        DateTime DataCriacao,
        int UsuarioId,
        int ClienteId,
        int Status,
        int Valor,
        string? NumeroPO,
        string? DocumentoPO,
        IList<FaturamentoItemResponse>? FaturamentoItem
    );

    public record FaturamentoItemResponse(
        int Id,
        int FaturamentoId, 
        int SolicitacaoId,
        Solicitacao2Faturamento Solicitacao
    );

    public record Solicitacao2Faturamento (
        int Id,
        DateTime DataSolicitacao,
        int ColaboradorId,
        int GestorId,
        decimal ValorDespesa
    );
}
