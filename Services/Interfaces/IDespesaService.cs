using AluraBackEnd1.Models;

namespace AluraBackEnd1.Services.Interfaces
{
    public interface IDespesaService
    {
        Task Insert(Despesa despesa);
        bool HasDespesaNoMesComAMesmaDescricao(Despesa despesa);
        Task<List<Despesa>> AllDespesas();
        Task<Despesa> GetById(int id);
        Task Update(Despesa despesa, int id);
        Task Delete(Despesa despesa);
    }
}
