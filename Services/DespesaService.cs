using AluraBackEnd1.Data;
using AluraBackEnd1.Data.DTO;
using AluraBackEnd1.Models;
using AluraBackEnd1.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AluraBackEnd1.Services
{
    public class DespesaService : IDespesaService
    {
        private FinanceiroContext _financeiroContext;
        private IMapper _mapper;

        public DespesaService(FinanceiroContext financeiroContext, IMapper mapper)
        {
            _financeiroContext = financeiroContext;
            _mapper = mapper;
        }

        public async Task<List<InserirDespesaDTO>> AllDespesas()
        { 
            var despesa = await _financeiroContext.Despesas.ToListAsync(); 
            return _mapper.Map<List<InserirDespesaDTO>>(despesa);
        }

        public async Task Delete(int id)
        {
            Despesa despesa = await _financeiroContext.Despesas.FirstOrDefaultAsync(x => x.Id == id);

            if(despesa != null)
            {
                _financeiroContext.Remove(despesa);
                await _financeiroContext.SaveChangesAsync();
            }
        }

        public async Task<InserirDespesaDTO> GetById(int id)
        {
            Despesa despesa = await _financeiroContext.Despesas.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<InserirDespesaDTO>(despesa);
        }

        public bool HasDespesaNoMesComAMesmaDescricao(InserirDespesaDTO despesa) => _financeiroContext.Despesas.Any(x => x.Descricao.ToUpper() == despesa.Descricao.ToUpper() &&
            x.Data.Month == despesa.Data.Month);

        public async Task Insert(InserirDespesaDTO despesa)
        {
            _financeiroContext.Despesas.Add(_mapper.Map<Despesa>(despesa));
            await _financeiroContext.SaveChangesAsync();
        }

        public async Task Update(InserirDespesaDTO despesa, int id)
        {
            Despesa item = _financeiroContext.Despesas.First(x => x.Id == id);
            _mapper.Map(despesa, item);

            _financeiroContext.Despesas.Update(item);
            await _financeiroContext.SaveChangesAsync();
        }
    }
}
