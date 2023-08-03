﻿using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using wca.reembolso.application.Contracts.Persistence;
using wca.reembolso.application.Features.Clientes.Behaviors;
using wca.reembolso.application.Features.Clientes.Common;
using wca.reembolso.domain.Entities;

namespace wca.reembolso.application.Features.Clientes.Commands
{
    public record ClienteCreateCommand (
        int FilialId,
        string Nome,
        string CNPJ,
        string InscricaoEstadual,
        string Endereco,
        string Numero,
        string CEP,
        string Cidade,
        string UF,
        decimal ValorLimite
    ) : IRequest<ErrorOr<ClienteResponse>>;

    public class ClienteCreateCommandHandler : IRequestHandler<ClienteCreateCommand, ErrorOr<ClienteResponse>>
    {
        private IClienteRepository _reposistory;
        private IMapper _mapper;
        private ILogger<ClienteCreateCommandHandler> _logger;

        public ClienteCreateCommandHandler(IClienteRepository reposistory, IMapper mapper, ILogger<ClienteCreateCommandHandler> logger)
        {
            _reposistory = reposistory;
            _mapper = mapper;
            _logger = logger;
        }

        async Task<ErrorOr<ClienteResponse>> IRequestHandler<ClienteCreateCommand, ErrorOr<ClienteResponse>>.Handle(ClienteCreateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateClienteCommandHandler - validation");
            //1. validar dados
            CreateClienteCommandBehavior validator = new CreateClienteCommandBehavior();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ConvertAll(x => Error.Validation(x.PropertyName, x.ErrorMessage));
                return errors;
            }

            //2. mapear para cliente e adicionar
            Cliente cliente = _mapper.Map<Cliente>(request);

            _reposistory.Create(cliente);

            await _reposistory.SaveChangesAsync();

            //3. mapear para clienteresponse
            return _mapper.Map<ClienteResponse>(cliente);
        }
    }
}
