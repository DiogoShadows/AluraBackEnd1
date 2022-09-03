using AluraBackEnd1.Data;
using AluraBackEnd1.Data.DTO;
using AluraBackEnd1.Models;
using AluraBackEnd1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AluraBackEnd1.Services
{
    public class ResumoService : IResumoService
    {
        private FinanceiroContext _financeiroContext;

        public ResumoService(FinanceiroContext financeiroContext)
        {
            _financeiroContext = financeiroContext;
        }

        public async Task<ResumoDTO> ResumoMes(int ano, int mes)
        {
            List<Despesa> despesas = await _financeiroContext.Despesas
                .Where(x => x.Data.Month == mes && x.Data.Year == ano)
                .ToListAsync();

            decimal totalReceitas = await _financeiroContext.Receitas
                .Where(x => x.Data.Month == mes && x.Data.Year == ano)
                .SumAsync(x => x.Valor);

            decimal totalDespesas = despesas.Sum(x => x.Valor);
            List<string> categoriasDespesas = new List<string>();

            despesas.GroupBy(x => x.Categoria).ToList().ForEach(item => categoriasDespesas.Add($"{item.Key}: {item.Sum(x => x.Valor)}"));

            return new ResumoDTO
            {
                TotalDespesasMes = totalDespesas,
                TotalReceitasMes = totalReceitas,
                SaldoFinal = totalReceitas - totalDespesas,
                DespesasTotalCategoria = categoriasDespesas,
            };
        }
    }
}
