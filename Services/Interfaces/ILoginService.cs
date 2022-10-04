

using AluraBackEnd1.Models;

namespace AluraBackEnd1.Services.Interfaces
{
    public interface ILoginService
    {
        Task Insert(DadosLogin login);
        Task<bool> SenhaCorreta(string email, string senha);
        object GerarToken(string email);
    }
}
