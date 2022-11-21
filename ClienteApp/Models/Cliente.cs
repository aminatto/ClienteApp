using System.ComponentModel.DataAnnotations;

namespace ClienteApp.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual Contato Contato { get; set; }

    }
}
