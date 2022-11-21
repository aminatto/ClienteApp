using AutoMapper;
using ClienteApp.Data.Dtos;
using ClienteApp.Models;
using ClienteApp.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApp.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService clienteService;
        private readonly IMapper mapper;

        public ClienteController(ClienteService clienteService, IMapper mapper)
        {
            this.clienteService = clienteService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ReadClienteDto> readDto = await clienteService.GetAsync();

                if (readDto != null)
                    return Ok(readDto);

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("listar/{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            try
            {
                var readDto = await clienteService.GetByCpfAsync(cpf);

                if (readDto != null)
                    return Ok(readDto);

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> Post([FromBody]CreateClienteDto clientDto)
        {
            try
            {
                Cliente cliente = mapper.Map<Cliente>(clientDto);
                ReadClienteDto readDto = await clienteService.CreateClientAsync(cliente);
                return CreatedAtAction(nameof(Post), new { Id = cliente.Id }, readDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<IActionResult> Put(string cpf, [FromBody] UpdateClienteDto clientDto)
        {
            try
            {
                Result result = await clienteService.UpdateAsync(cpf, clientDto);

                if (result.IsFailed)
                    return NotFound();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("remover")]
        public async Task<IActionResult> Delete(string cpf)
        {
            try
            {
                Result result = await clienteService.DeleteAsync(cpf);

                if (result.IsFailed)
                    return NotFound();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
