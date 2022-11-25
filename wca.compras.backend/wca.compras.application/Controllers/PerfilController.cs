﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using wca.compras.domain.Interfaces.Services;
using wca.compras.domain.Util;
using wca.compras.domain.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace wca.compras.webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize("Bearer")]
    public class PerfilController : Controller
    {
        private readonly IPerfilService service;
        public PerfilController(IPerfilService perfilService)
        {
            service = perfilService;
        }

        /// <summary>
        /// Cadastra um novo perfil e suas permissões
        /// </summary>
        /// <returns>Perfil com permissões</returns>
        /// <param name="perfilDto"></param>
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreatePerfilDto perfilDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await service.Create(perfilDto);
                return Created("", result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Atualiza dados do perfil, atribui/remove permissão
        /// </summary>
        /// <returns>Perfil com permissões</returns>
        /// <param name="perfilDto"></param>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdatePerfilDto perfilDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await service.Update(perfilDto);
                if (result == null)
                {
                    return NotFound($"Perfil íd: {perfilDto.Id}, não localizado!");
                }
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Busca o perfil com suas respectivas permissões
        /// </summary>
        /// <returns>Perfil com permissões</returns>
        /// <param name="id"></param>
        [HttpGet]
        [Route("GetWithPermissions/{id}")]
        public async Task<ActionResult<PerfilPermissoesDto>> GetWithPermissions(string id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var result = await service.GetWithPermissoes(id);
                if (result == null)
                {
                    return NotFound($"Perfil íd: {id}, não localizado!");
                }
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retorna lista de perfil ativos para preenchimento de Listas e Combos
        /// </summary>
        /// <returns>Perfil com permissões</returns>
        [HttpGet]
        [Route("ToList")]
        public async Task<ActionResult<IList<ListItem>>> List()
        {
            var items = await service.GetToList();
            return Ok(items);
        }

        /// <summary>
        /// Retorna Perfil por paginação
        /// </summary>
        /// <returns>Perfil</returns>
        [HttpGet]
        [Route("Paginate/{pageSize}/{page}")]
        public async Task<ActionResult<Pagination<PerfilDto>>> Paginate(int pageSize = 10, int page = 1, string? termo = "")
        {
            var items = await service.Paginate(page, pageSize, termo);
            return Ok(items);
        }
    }
}
