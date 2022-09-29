using AluraBackEnd1.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraBackEnd1.Data
{
    public class FinanceiroContext : DbContext
    {
        public FinanceiroContext(DbContextOptions<FinanceiroContext> opt) : base (opt)
        {

        }

        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<DadosLogin> DadosLogins { get; set; }
    }
}
