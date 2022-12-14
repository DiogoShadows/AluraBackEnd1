    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

namespace AluraBackEnd1.Models
{
    public class Despesa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime Data { get; set; }

        [StringLength(50)]
        public string Categoria { get; set; } 
    }
}
