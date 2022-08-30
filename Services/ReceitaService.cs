using AluraBackEnd1.Data;
using AluraBackEnd1.Models;
using AluraBackEnd1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AluraBackEnd1.Services
{
    public class ReceitaService : IReceitaService
    {
        private FinanceiroContext _financeiroContext;

        public ReceitaService(FinanceiroContext financeiroContext)
        {
            _financeiroContext = financeiroContext;
        }

        public async Task Insert(Receita receita)
        {
            _financeiroContext.Receitas.Add(receita);
            await _financeiroContext.SaveChangesAsync();
        }

        public bool HasReceitaNoMesComAMesmaDescricao(Receita receita) => _financeiroContext.Receitas.Any(x => x.Descricao.ToUpper() == receita.Descricao.ToUpper() && 
            x.Data.Month == receita.Data.Month);

        public async Task<List<Receita>> AllReceitas() => await _financeiroContext.Receitas.ToListAsync();

        public async Task<Receita> GetById(int id) => await _financeiroContext.Receitas.FirstOrDefaultAsync(x => x.Id == id);

        public async Task Update(Receita receita, int id)
        {
            Receita item = await GetById(id);
            item.Descricao = receita.Descricao;
            item.Data = receita.Data;
            item.Valor = receita.Valor;

            _financeiroContext.Receitas.Update(item);
            await _financeiroContext.SaveChangesAsync();
        }
    }
}
