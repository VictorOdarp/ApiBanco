using ApiBanco.Interface;
using ApiBanco.Models;
using ApiBanco.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
