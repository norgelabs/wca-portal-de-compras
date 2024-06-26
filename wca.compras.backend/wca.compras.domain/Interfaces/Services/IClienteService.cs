﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wca.compras.domain.Dtos;
using wca.compras.domain.Util;

namespace wca.compras.domain.Interfaces.Services
{
    public interface IClienteService
    {
        public Task<ClienteDto> Create(CreateClienteDto cliente);
        public Task<ClienteDto> Update(UpdateClienteDto cliente);
        public Task<bool> Remove(int id);
        public Task<IList<ClienteDto>> GetAll();
        public Task<ClienteDto> GetById(int id);
        public Pagination<ClienteDto> Paginate(int[] filialId, int page = 1, int pageSize = 10, string termo = "");
        public Task<IList<ListItem>> GetToList(int[] filialId);
        public Task<IList<ClienteDto>> GetByUser(int usuarioId, int[]? filial = null);

        Task<bool> ImportarDadosClientes(ClienteImportacaoDto clienteImportacaoDto);
    }
}
