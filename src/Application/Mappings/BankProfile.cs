using PaymentDemo.Application.Features.Banks.Commands;
using PaymentDemo.Application.Features.Banks.Queries;

namespace PaymentDemo.Application.Mappings
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<CreateBankCommand, Bank>().ReverseMap();
            CreateMap<GetBankResponse, Bank>().ReverseMap();
        }
    }
}