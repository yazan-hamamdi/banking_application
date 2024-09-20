using Banking_application_Business.IServices;
using banking_application_Data.Entities;
using banking_application_Data.IEntities;
using Microsoft.AspNetCore.Mvc;

namespace Banking_application_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionHistoryController : ControllerBase
    {
        private readonly ITransactionHistoryService _transactionHistoryService;
        public TransactionHistoryController(ITransactionHistoryService transactionHistoryService)
        {
            _transactionHistoryService = transactionHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionHistories()
        {
            var transactionHistories = await _transactionHistoryService.GetAllAsync();
            return Ok(transactionHistories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionHistoryById(int id)
        {
            var transactionHistory = await _transactionHistoryService.GetByIdAsync(id);
            if (transactionHistory == null)
                return NotFound();

            return Ok(transactionHistory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransactionHistory(TransactionHistory transactionHistory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTransactionHistory = await _transactionHistoryService.AddAsync(transactionHistory);
            return CreatedAtAction(nameof(GetTransactionHistoryById), new { id = createdTransactionHistory.Id }, createdTransactionHistory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransactionHistory(int id,TransactionHistory transactionHistory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedTransactionHistory = await _transactionHistoryService.UpdateAsync(transactionHistory, id);
            if (updatedTransactionHistory == null)
                return NotFound();

            return Ok(updatedTransactionHistory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionHistory(int id)
        {
            await _transactionHistoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
