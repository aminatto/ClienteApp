﻿namespace ClienteApp.Data.Dtos
{
    public class UpdateEnderecoDto
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Bairro { get; set; }

        public string Complemento { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Referencia { get; set; }
    }
}
