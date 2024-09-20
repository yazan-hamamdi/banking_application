using Banking_application_Business.DTOs;
using banking_application_Data.Entities;
using banking_application_Data.Enums;
using banking_application_Data.IEntities;

namespace Banking_application_Business.IServices
{
    public interface IAccountService
    {
        Task<ICollection<AccountWithoutId>> GetAllAsync();
        Task<AccountWithoutId> GetByIdAsync(int id);
        Task<AccountWithId> AddAsync(AccountWithId account);
        Task<AccountWithoutId> UpdateAsync(AccountWithId account, int id);
        Task DeleteAsync(int id);
        Task<bool> DepositAsync(int accountId, decimal amount);
        Task<bool> WithdrawAsync(int accountId, decimal amount);
        Task<int> NumberOfAccountCreationsInGivenMonth(Months month);
        Task<ICollection<AccountWithoutId>> DisplayTheThreeHighestBalanceAsync();
        Task<decimal> TotalBalanceAsync();
        Task<ICollection<AccountWithoutId>> LowBalanceAsync(decimal threshold);//
        Task<ICollection<AccountWithoutId>> MediumBalanceAsync(decimal min, decimal max);//
        Task<ICollection<AccountWithoutId>> HighBalanceAsync(decimal threshold);//
    }
}
