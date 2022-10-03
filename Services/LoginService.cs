using AluraBackEnd1.Data;
using AluraBackEnd1.Models;
using AluraBackEnd1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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
            login.Senha = StringEncriptada(login.Senha);
            _financeiroContext.DadosLogins.Add(login);
            await _financeiroContext.SaveChangesAsync();
        }

        public async Task<bool> SenhaCorreta(string email, string senha)
        {
            senha = StringEncriptada(senha);

            return await _financeiroContext.DadosLogins.AnyAsync(x => x.Email.Equals(email.ToLower().Trim()) && x.Senha == senha);
        }

        private string StringEncriptada(string palavra)
        {
            StringBuilder sb = new StringBuilder();
            HashAlgorithm algorithm = SHA256.Create();
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(palavra));

            foreach (byte caracter in hash)
                sb.Append(caracter.ToString("X2"));

            return sb.ToString();
        }

    }
}
