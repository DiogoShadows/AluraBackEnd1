using AluraBackEnd1.Models;

namespace AluraBackEnd1.Services.Interfaces
{
    public interface IReceitaService
    {
        Task Insert(Receita receita);
        bool HasReceitaNoMesComAMesmaDescricao(Receita receita);
        Task<List<Receita>> AllReceitas();
        Task<Receita> GetById(int id); 
    }
}
