using AluraBackEnd1.Data.DTO;
using AluraBackEnd1.Models;

namespace AluraBackEnd1.Services.Interfaces
{
    public interface IDespesaService
    {
        Task Insert(InserirDespesaDTO despesa);
        bool HasDespesaNoMesComAMesmaDescricao(InserirDespesaDTO despesa);
        Task<List<InserirDespesaDTO>> AllDespesas();
        Task<InserirDespesaDTO> GetById(int id);
        Task Update(InserirDespesaDTO despesa, int id);
        Task Delete(int id);
    }
}
