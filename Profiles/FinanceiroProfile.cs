using AluraBackEnd1.Data.DTO;
using AluraBackEnd1.Models;
using AutoMapper;

namespace AluraBackEnd1.Profiles
{
    public class FinanceiroProfile : Profile
    {
        public FinanceiroProfile()
        {
            CreateMap<InserirReceitaDTO, Receita>().ReverseMap();
            CreateMap<InserirDespesaDTO, Despesa>().ReverseMap();
        }
    }
}
