using AutoMapper;
using Banking_application_Business.DTOs;
using Banking_application_Business.IServices;
using banking_application_Data.Entities;
using banking_application_Data.IRepositories;

namespace Banking_application_Business.Services
{
    public class TransactionHistoryService : ITransactionHistoryService
    {
        private readonly ITransactionHistoryRepo _transactionHistoryRepo;
        private readonly IMapper _mapper;

        public TransactionHistoryService(ITransactionHistoryRepo transactionHistoryRepo, IMapper mapper)
        {
            _transactionHistoryRepo = transactionHistoryRepo;
            _mapper = mapper;
        }

        public async Task<TransWithId> AddAsync(TransWithId transactionHistoryDto)
        {
            var transactionHistory = _mapper.Map<TransactionHistory>(transactionHistoryDto);
            await _transactionHistoryRepo.AddAsync(transactionHistory);
            return _mapper.Map<TransWithId>(transactionHistory);
        }

        public async Task DeleteAsync(int id)
        {
            await _transactionHistoryRepo.DeleteAsync(id);
        }

        public async Task<ICollection<TransWithoutId>> GetAllAsync()
        {
            var transactionHistories = await _transactionHistoryRepo.GetAllAsync();
            return _mapper.Map<ICollection<TransWithoutId>>(transactionHistories);
        }

        public async Task<TransWithoutId> GetByIdAsync(int id)
        {
            var transactionHistory = await _transactionHistoryRepo.GetByIdAsync(id);
            return _mapper.Map<TransWithoutId>(transactionHistory);
        }

        public async Task<TransWithoutId> UpdateAsync(TransWithId transactionHistoryDto, int id)
        {
            var transactionHistory = _mapper.Map<TransactionHistory>(transactionHistoryDto);
            var updatedTransactionHistory = await _transactionHistoryRepo.UpdateAsync(transactionHistory, id);
            return _mapper.Map<TransWithoutId>(updatedTransactionHistory);
        }
    }
}
