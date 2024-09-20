using Banking_application_Business.DTOs;
using banking_application_Data.Entities;

namespace Banking_application_Business.Profile
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerWithId>().ReverseMap();
            CreateMap<Customer, CustomerWithoutId>().ReverseMap();
        }
    }
}
