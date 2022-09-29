using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AluraBackEnd1.Models
{
    public class DadosLogin
    {
        [Key]
        [StringLength(100)]
        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string Senha { get; set; }
    }
}
