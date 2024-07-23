using ApiBanco.Dto.Account;
using ApiBanco.Interface;
using ApiBanco.Models;
using ApiBanco.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

namespace ApiBanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountInterface _accountInterface;

        public AccountController(IAccountInterface accountInterface)
        {
            _accountInterface = accountInterface;
        }

        [HttpGet("GetAllAccounts")]
        public async Task<ActionResult<ServiceResponse<List<AccountModel>>>> GetAllAccounts()
        {
            var listAccount = await _accountInterface.GetAllAccounts();
            return Ok(listAccount);
        }

        [HttpGet("GetAccountById")]
        public async Task<ActionResult<ServiceResponse<List<AccountModel>>>> GetAccountById(int id)
        {
            var account = await _accountInterface.GetAccountById(id);
            return Ok(account);
        }

        [HttpPost("CreateAccount")]
        public async Task<ActionResult<ServiceResponse<List<AccountModel>>>> CreateAccount(CriacaoAccountDto newAccount)
        {
            var account = await _accountInterface.CreateAccount(newAccount);
            return Ok(account);
        }

        [HttpPut("EditAccount")]
        public async Task<ActionResult<ServiceResponse<List<AccountModel>>>> EditAccount(EdicaoAccountDto editAccount)
        {
            var account = await _accountInterface.EditAccount(editAccount);
            return Ok(account);
        }

        [HttpDelete("RemoveAccount")]
        public async Task<ActionResult<ServiceResponse<AccountModel>>> RemoveAccount(int id)
        {
            var account = await _accountInterface.RemoveAccount(id);
            return Ok(account);
        }

        [HttpPut("DepositAccount/{id}/{value}")]
        public async Task<ActionResult<ServiceResponse<AccountModel>>> DepositAccount(int id, double value)
        {
            var account = await _accountInterface.DepositAccount(id, value);
            return Ok(account);
        }

        [HttpPut("WithdrawAccount/{id}/{value}")]
        public async Task<ActionResult<ServiceResponse<AccountModel>>> WithdrawAccount(int id, double value)
        {
            var account = await _accountInterface.WithdrawAccount(id, value);
            return Ok(account);
        }
    }
}
