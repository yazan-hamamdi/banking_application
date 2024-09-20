using AutoMapper;
using banking_application_Data.Entities;
using Banking_application_Business.DTOs;

namespace Banking_application_Business.Profile
{
    public class AccountProfile : AutoMapper.Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountWithId>().ReverseMap();
            CreateMap<Account, AccountWithoutId>().ReverseMap();
        }
    }
}
