using AluraBackEnd1.Data.DTO;
using AluraBackEnd1.Models;

namespace AluraBackEnd1.Services.Interfaces
{
    public interface IReceitaService
    {
        Task Insert(InserirReceitaDTO receita);
        bool HasReceitaNoMesComAMesmaDescricao(InserirReceitaDTO receita);
        Task<List<InserirReceitaDTO>> AllReceitas(string? descricao);
        Task<InserirReceitaDTO> GetById(int id);
        Task Update(InserirReceitaDTO receita, int id);
        Task Delete(int id);
    }
}
