using AluraBackEnd1.Data.DTO;

namespace AluraBackEnd1.Services.Interfaces
{
    public interface IResumoService
    {
        Task<ResumoDTO> ResumoMes(int ano, int mes);
    }
}
