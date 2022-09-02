using System.ComponentModel.DataAnnotations;

namespace AluraBackEnd1.Data.DTO
{
    public class InserirDespesaDTO
    {
        [StringLength(50)]
        [Required(ErrorMessage = "O descrição é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime Data { get; set; }

        [StringLength(50)]
        public string Categoria { get; set; } = "Outros";
    }
}
