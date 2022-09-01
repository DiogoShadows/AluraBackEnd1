using AluraBackEnd1.Data;
using AluraBackEnd1.Models;
using AluraBackEnd1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AluraBackEnd1.Services
{
    public class DespesaService : IDespesaService
    {
        private FinanceiroContext _financeiroContext;

        public DespesaService(FinanceiroContext financeiroContext)
        {
            _financeiroContext = financeiroContext;
        }

        public async Task<List<Despesa>> AllDespesas() => await _financeiroContext.Despesas.ToListAsync();

        public async Task Delete(Despesa despesa)
        {
            _financeiroContext.Remove(despesa);
            await _financeiroContext.SaveChangesAsync();
        }

        public async Task<Despesa> GetById(int id) => await _financeiroContext.Despesas.FirstOrDefaultAsync(x => x.Id == id);

        public bool HasDespesaNoMesComAMesmaDescricao(Despesa despesa) => _financeiroContext.Despesas.Any(x => x.Descricao.ToUpper() == despesa.Descricao.ToUpper() &&
            x.Data.Month == despesa.Data.Month);

        public async Task Insert(Despesa despesa)
        {
            _financeiroContext.Despesas.Add(despesa);
            await _financeiroContext.SaveChangesAsync();
        }

        public async Task Update(Despesa despesa, int id)
        {
            Despesa item = await GetById(id);
            item.Descricao = despesa.Descricao;
            item.Data = despesa.Data;
            item.Valor = despesa.Valor;

            _financeiroContext.Despesas.Update(item);
            await _financeiroContext.SaveChangesAsync();
        }
    }
}
