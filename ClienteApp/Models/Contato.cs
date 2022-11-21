using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClienteApp.Models
{
    public class Contato
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }

        public string Email { get; set; }

        public string DDD { get; set; }

        public string Telefone { get; set; }
        
    }
}
