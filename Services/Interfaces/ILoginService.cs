

using AluraBackEnd1.Models;

namespace AluraBackEnd1.Services.Interfaces
{
    public interface ILoginService
    {
        Task Insert(DadosLogin login);
        bool SenhaCorreta(DadosLogin login);
    }
}
