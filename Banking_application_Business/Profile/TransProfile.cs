using Banking_application_Business.DTOs;
using banking_application_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_application_Business.Profile
{
    public class TransProfile : AutoMapper.Profile
    {
        public TransProfile()
        {
            CreateMap<TransactionHistory, TransWithId>().ReverseMap();
            CreateMap<TransactionHistory, TransWithoutId>().ReverseMap();
        }
    }
}
