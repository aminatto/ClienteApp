using System.Collections.Generic;

namespace ClienteApp.Data.Dtos
{
    public class ReadClienteDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public ReadEnderecoDto Endereco { get; set; }
       
        public ReadContatoDto Contato { get; set; }
    }
}
