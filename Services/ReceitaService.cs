using AluraBackEnd1.Data;
using AluraBackEnd1.Data.DTO;
using AluraBackEnd1.Models;
using AluraBackEnd1.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AluraBackEnd1.Services
{
    public class ReceitaService : IReceitaService
    {
        private FinanceiroContext _financeiroContext;
        private IMapper _mapper;

        public ReceitaService(FinanceiroContext financeiroContext, IMapper mapper)
        {
            _financeiroContext = financeiroContext;
            _mapper = mapper;
        }

        public async Task Insert(InserirReceitaDTO receita)
        {
            _financeiroContext.Receitas.Add(_mapper.Map<Receita>(receita));
            await _financeiroContext.SaveChangesAsync();
        }

        public bool HasReceitaNoMesComAMesmaDescricao(InserirReceitaDTO receita) => _financeiroContext.Receitas.Any(x => x.Descricao.ToUpper() == receita.Descricao.ToUpper() && 
            x.Data.Month == receita.Data.Month);

        public async Task<List<InserirReceitaDTO>> AllReceitas()
        {
            List<Receita> receita = await _financeiroContext.Receitas.ToListAsync();
            return _mapper.Map<List<InserirReceitaDTO>>(receita);
        }

        public async Task<InserirReceitaDTO> GetById(int id)
        {
            Receita receita = await _financeiroContext.Receitas.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<InserirReceitaDTO>(receita);
        }

        public async Task Update(InserirReceitaDTO receita, int id)
        {
            Receita item = await _financeiroContext.Receitas.FirstAsync(x => x.Id == id);
            _mapper.Map(receita, item);

            _financeiroContext.Receitas.Update(item);
            await _financeiroContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Receita receita = await _financeiroContext.Receitas.FirstOrDefaultAsync(x => x.Id == id);

            if(receita != null)
            {
                _financeiroContext.Remove(receita);
                await _financeiroContext.SaveChangesAsync();
            }
        }
    }
}
