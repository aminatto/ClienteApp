using AutoMapper;
using ClienteApp.Data;
using ClienteApp.Data.Dtos;
using ClienteApp.Extension;
using ClienteApp.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApp.Services
{
    public class ClienteService
    {
        private AppDbContext context;
        private IMapper mapper;

        public ClienteService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ReadClienteDto> CreateClientAsync(Cliente cliente)
        {
            var cpf = cliente.Cpf.NormalizeString();
            cliente.Cpf = cpf;

            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            return mapper.Map<ReadClienteDto>(cliente);
        }

        public async Task<List<ReadClienteDto>> GetAsync()
        {
            List<Cliente> clientes = await context.Clientes.Include(x => x.Contato).Include(x => x.Endereco).ToListAsync();

            if (clientes == null)
                return null;

            return mapper.Map<List<ReadClienteDto>>(clientes);
        }

        public async Task<ReadClienteDto> GetByCpfAsync(string cpf)
        {
            Cliente cliente = await context.Clientes.Include(x => x.Contato).Include(x => x.Endereco)
                .FirstOrDefaultAsync(x => x.Cpf == cpf.NormalizeString());

            if (cliente == null)
                return null;

            return mapper.Map<ReadClienteDto>(cliente);
        }

        public async Task<Result> DeleteAsync(string cpf)
        {
            Cliente cliente = await context.Clientes.Include(x => x.Contato).Include(x => x.Endereco)
                .FirstOrDefaultAsync(x => x.Cpf == cpf.NormalizeString());

            if (cliente == null)
                return Result.Fail("Cliente não encontrado.");

            context.Clientes.Remove(cliente);
            context.Contatos.Remove(cliente.Contato);
            context.Enderecos.Remove(cliente.Endereco);
            await context.SaveChangesAsync();

            return Result.Ok();
        }

        public async Task<Result> UpdateAsync(string cpf, UpdateClienteDto clientDto)
        {
            Cliente cliente = await context.Clientes.Include(x => x.Contato).Include(x => x.Endereco)
                .FirstOrDefaultAsync(x => x.Cpf == cpf.NormalizeString());

            if (cliente == null)
                return Result.Fail("Cliente não encontrado.");

            mapper.Map(clientDto, cliente);

            context.Clientes.Update(cliente);
            await context.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
