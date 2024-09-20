using AutoMapper;
using Banking_application_Business.DTOs;
using Banking_application_Business.IServices;
using banking_application_Data.Entities;
using banking_application_Data.Enums;
using banking_application_Data.IRepositories;
using System.Collections.Generic;

namespace Banking_application_Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepo accountRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }

        public async Task<Account> AddAsync(AccountWithId account)
        {
            var realAccount = _mapper.Map<Account>(account); 
            await _accountRepo.AddAsync(realAccount);
            var accountWithId = _mapper.Map<AccountWithId>(realAccount);

            return accountWithId;
        }
        public async Task DeleteAsync(int id)
        {
            await _accountRepo.DeleteAsync(id);
        }

        public async Task<ICollection<AccountWithoutId>> GetAllAsync()
        {
            var accounts = await _accountRepo.GetAllAsync();
            return _mapper.Map<ICollection<AccountWithoutId>>(accounts);
        }

        public async Task<AccountWithoutId> GetByIdAsync(int id)
        {
            var account = await _accountRepo.GetByIdAsync(id);
            return _mapper.Map<AccountWithoutId>(account);
        }

        public async Task<AccountWithoutId> UpdateAsync(AccountWithId account, int id)
        {
            var realAccount = _mapper.Map<Account>(account);
            var acc = await _accountRepo.UpdateAsync(realAccount, id);
            var accWithId = _mapper.Map<AccountWithoutId>(acc);
            return accWithId;
        }

        public async Task<int> NumberOfAccountCreationsInGivenMonth(Months month)
        {
            var accounts = await _accountRepo.GetAllAsync();
            return accounts.Count(a => a.CreationDate.Month == (int)month);
        }

        public async Task<ICollection<AccountWithoutId>> DisplayTheThreeHighestBalanceAsync()
        {
            var accounts = await _accountRepo.GetAllAsync();
            var topThreeAccounts = accounts.OrderByDescending(a => a.Balance).Take(3).ToList();

            return _mapper.Map < ICollection < AccountWithoutId >>( topThreeAccounts);
        }

        public async Task<decimal> TotalBalanceAsync()
        {
            var accounts = await _accountRepo.GetAllAsync();
            return accounts.Sum(a => a.Balance);
        }

        public async Task<ICollection<AccountWithoutId>> LowBalanceAsync(decimal threshold)
        {
            var accounts = await _accountRepo.GetAllAsync();
            var filteredAccounts = accounts.Where(a => a.Balance < threshold).ToList();
            return _mapper.Map<ICollection<AccountWithoutId>>(filteredAccounts);
        }

        public async Task<ICollection<AccountWithoutId>> MediumBalanceAsync(decimal min, decimal max)
        {
            var accounts = await _accountRepo.GetAllAsync();
            var filteredAccounts = accounts.Where(a => a.Balance >= min && a.Balance <= max).ToList();
            return _mapper.Map<ICollection<AccountWithoutId>>(filteredAccounts);
        }

        public async Task<ICollection<AccountWithoutId>> HighBalanceAsync(decimal threshold)
        {
            var accounts = await _accountRepo.GetAllAsync();
            var filteredAccounts = accounts.Where(a => a.Balance > threshold).ToList();
            return _mapper.Map<ICollection<AccountWithoutId>>(filteredAccounts);
        }

        public async Task<bool> DepositAsync(int accountId, decimal amount)
        {
            var account = await _accountRepo.GetByIdAsync(accountId);
            if (account == null) return false;

            account.Balance += amount;
            await _accountRepo.UpdateAsync(account, accountId);
            return true;
        }

        public async Task<bool> WithdrawAsync(int accountId, decimal amount)
        {
            var account = await _accountRepo.GetByIdAsync(accountId);
            if (account == null || account.Balance < amount) return false;

            account.Balance -= amount;
            await _accountRepo.UpdateAsync(account, accountId);
            return true;
        }
    }
}
