using ClienteApp.Models;
using System.Collections.Generic;

namespace ClienteApp.Data.Dtos
{
    public class CreateClienteDto
    {
        public string Nome { get; set; }
        
        public string Cpf { get; set; }
        
        public string Rg { get; set; }
        
        public CreateEnderecoDto Endereco { get; set; }
        
        public CreateContatoDto Contato { get; set; }
    }
}
