namespace AluraBackEnd1.Data.DTO
{
    public class ResumoDTO
    {
        public decimal TotalReceitasMes { get; set; }
        public decimal TotalDespesasMes { get; set; }
        public decimal SaldoFinal { get; set; }
        public List<string> DespesasTotalCategoria { get; set; }
    }
}
