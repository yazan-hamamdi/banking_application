using Banking_application_Business.IServices;
using banking_application_Data.Entities;
using banking_application_Data.IEntities;
using Microsoft.AspNetCore.Mvc;

namespace Banking_application_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                var accounts = await _accountService.GetAllAsync();
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving accounts.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            try
            {
                var account = await _accountService.GetByIdAsync(id);
                if (account == null) return NotFound("Account not found");

                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the account.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(Account account)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdAccount = await _accountService.AddAsync(account);
                return Ok(createdAccount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the account.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account account)
        {
            try
            {
                var updatedAccount = await _accountService.UpdateAsync(account, id);
                if (updatedAccount == null)
                    return NotFound("Account not found");

                return Ok(updatedAccount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the account.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                await _accountService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the account.");
            }
        }

        [HttpPost("{id}/Deposit")]
        public async Task<IActionResult> Deposit(int id, decimal amount)
        {
            try
            {
                var success = await _accountService.DepositAsync(id, amount);
                if (!success)
                    return BadRequest("Deposit failed");

                return Ok("Deposit successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the deposit.");
            }
        }

        [HttpPost("{id}/Withdraw")]
        public async Task<IActionResult> Withdraw(int id, decimal amount)
        {
            try
            {
                var success = await _accountService.WithdrawAsync(id, amount);
                if (!success)
                    return BadRequest("Withdrawal failed");

                return Ok("Withdrawal successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the withdrawal.");
            }
        }

        [HttpGet("TopThreeBalances")]
        public async Task<IActionResult> GetTopThreeBalances()
        {
            try
            {
                var topThreeAcc = await _accountService.DisplayTheThreeHighestBalanceAsync();
                return Ok(topThreeAcc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the top three balances.");
            }
        }

        [HttpGet("TotalBalance")]
        public async Task<IActionResult> GetTotalBalance()
        {
            try
            {
                var totalBalance = await _accountService.TotalBalanceAsync();
                return Ok(totalBalance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while calculating the total balance.");
            }
        }

        [HttpGet("LowBalance")]
        public async Task<IActionResult> GetLowBalanceAccounts(decimal threshold)
        {
            try
            {
                var accounts = await _accountService.LowBalanceAsync(threshold);
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving low balance accounts.");
            }
        }

        [HttpGet("MediumBalance")]
        public async Task<IActionResult> GetMediumBalanceAccounts(decimal min, decimal max)
        {
            try
            {
                var accounts = await _accountService.MediumBalanceAsync(min, max);
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving medium balance accounts.");
            }
        }

        [HttpGet("HighBalance")]
        public async Task<IActionResult> GetHighBalanceAccounts(decimal threshold)
        {
            try
            {
                var accounts = await _accountService.HighBalanceAsync(threshold);
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving high balance accounts.");
            }
        }
    }
}
