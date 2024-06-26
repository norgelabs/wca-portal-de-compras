﻿using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using wca.reembolso.application.Contracts.Persistence;
using wca.reembolso.domain.Entities;

namespace wca.reembolso.application.Features.Usuarios.Queries
{
    public record UsuarioListarCentrodeCustoQuery(
        int UsuarioId,
        int ClienteId = 0
    ):IRequest<ErrorOr<IList<CentroCusto>>>;
    internal class UsuarioListarCentrodeCustoQueryHandle : IRequestHandler<UsuarioListarCentrodeCustoQuery, ErrorOr<IList<CentroCusto>>>
    {
        private IRepositoryManager _repository;
        private IMapper _mapper;

        public UsuarioListarCentrodeCustoQueryHandle(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<IList<CentroCusto>>> Handle(UsuarioListarCentrodeCustoQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.CentroCustoRepository.ToQuery()
                .Include(q => q.Usuarios)
                .Where(q => q.Usuarios.Any(c => c.UsuarioId.Equals(request.UsuarioId)));
                

            if (request.ClienteId > 0)
            {
                query = query.Where(q => q.ClienteId.Equals(request.ClienteId));
            }
            query = query.OrderBy(o => o.Nome);

            List<CentroCusto>? lista = await query.ToListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<List<CentroCusto>>(lista);
        }
    }
}
