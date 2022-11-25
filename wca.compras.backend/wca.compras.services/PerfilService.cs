﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using wca.compras.domain.Dtos;
using wca.compras.domain.Entities;
using wca.compras.domain.Interfaces;
using wca.compras.domain.Interfaces.Services;
using wca.compras.domain.Util;


namespace wca.compras.services
{
    public class PerfilService : IPerfilService
    {
        private readonly IRepositoryManager _rm;
        private IMapper _mapper;

        public PerfilService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _rm = repositoryManager;
            _mapper = mapper;
        }
        
        public async Task<PerfilDto> Create(CreatePerfilDto perfil)
        {
            var data = _mapper.Map<Perfil>(perfil);
            
            _rm.PerfilRepository.Attach(data);
            foreach (var permissao in perfil.Permissoes)
            {
                var perm = _mapper.Map<Permissao>(permissao);
                _rm.PermissaoRepository.Attach(perm);
                data.Permissao.Add(perm);
            }
            await _rm.SaveAsync();

            return _mapper.Map<PerfilDto>(data);
        }

        public async Task<IList<ListItem>> GetToList()
        {
            var itens = await _rm.PerfilRepository.SelectByCondition(p => p.Ativo == true)
                .OrderBy(p => p.Nome)
                .ToListAsync();

            return _mapper.Map<IList<ListItem>>(itens); 
        }

        public async Task<PerfilPermissoesDto> GetWithPermissoes(string id)
        {
            var data = await _rm.PerfilRepository.SelectByCondition(p => p.Id == int.Parse(id))
                .Include(pm => pm.Permissao).FirstOrDefaultAsync();

            return _mapper.Map<PerfilPermissoesDto>(data);
        }

        public async Task<PerfilDto> Update(UpdatePerfilDto perfil)
        {

            var baseData = await _rm.PerfilRepository
                            .SelectByCondition(p => p.Id == perfil.Id, true)
                            .Include("Permissao")
                            .FirstOrDefaultAsync();

            if (baseData == null)
            {
                return null;
            }

            //Remover permissões caso tenha alterado
            baseData.Permissao.ToList().ForEach(async permissao =>
            {
                var perm = perfil.Permissao.Where(p => p.Id == permissao.Id).FirstOrDefault();
                if (perm == null)
                {
                    var pm = baseData.Permissao.FirstOrDefault(p => p.Id == permissao.Id);
                    baseData.Permissao.Remove(pm);
                }
            });

            //Adicionar permissões caso tenha novas
            perfil.Permissao.ToList().ForEach(permissao =>
            {
                if (baseData.Permissao.Where(p => p.Id == permissao.Id).FirstOrDefault() == null)
                {
                    var mPerm = _mapper.Map<Permissao>(permissao);
                    _rm.PermissaoRepository.Attach(mPerm);
                    baseData.Permissao.Add(mPerm);
                }
            });

            baseData.Nome = perfil.Nome;
            baseData.Descricao = perfil.Descricao;
            baseData.Ativo = perfil.Ativo;

            await _rm.SaveAsync();

            return _mapper.Map<PerfilDto>(baseData);

        }

        public async Task<Pagination<PerfilDto>> Paginate(int page, int pageSize = 10, string termo = "")
        {
            var query = _rm.PerfilRepository.SelectAll();

            if (!string.IsNullOrEmpty(termo))
            {
                query = query.Where(q => q.Nome.Contains(termo));
            }
            query = query.OrderBy(p => p.Nome);

            var pagination = Pagination<PerfilDto>.ToPagedList(query, page, pageSize);

            return pagination;

        }
    }
}
