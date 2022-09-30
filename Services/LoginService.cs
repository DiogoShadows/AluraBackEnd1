using AluraBackEnd1.Data;
using AluraBackEnd1.Models;
using AluraBackEnd1.Services.Interfaces;

namespace AluraBackEnd1.Services
{
    public class LoginService : ILoginService
    {
        FinanceiroContext _financeiroContext;

        public LoginService(FinanceiroContext financeiroContext)
        {
            _financeiroContext = financeiroContext;
        }

        public async Task Insert(DadosLogin login)
        {
            _financeiroContext.DadosLogins.Add(login);
            await _financeiroContext.SaveChangesAsync();
        }

        public bool SenhaCorreta(DadosLogin login)
        {
            string senha = login.Senha
            return _financeiroContext.DadosLogins.Any(x => x.Email.Equals(login.Email.ToLower().Trim()) && x.Senha == senha);
        }

    }
}
