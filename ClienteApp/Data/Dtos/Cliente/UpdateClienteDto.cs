using System.Collections.Generic;

namespace ClienteApp.Data.Dtos
{
    public class UpdateClienteDto
    {
        public string Nome { get; set; }

        public UpdateEnderecoDto Endereco { get; set; }

        public UpdateContatoDto Contato { get; set; }
    }
}
