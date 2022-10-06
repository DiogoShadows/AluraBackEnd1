using AluraBackEnd1.Data;
using AluraBackEnd1.Models;
using AluraBackEnd1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public object GerarToken(string email)
        {
            var chaves = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaves["SecretKey"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: chaves["Issuer"],
                audience: chaves["Audience"],
                claims: new List<Claim>() { new Claim(JwtRegisteredClaimNames.Email, email) },
                expires: DateTime.Now.AddHours(8),
                signingCredentials: signinCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return new { Email = email, Token = token };
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
