using ApiBanco.Dto.Account;
using ApiBanco.Models;
using ApiBanco.Services;

namespace ApiBanco.Interface
{
    public interface IAccountInterface
    {
        public Task<ServiceResponse<List<AccountModel>>> GetAllAccounts();
        public Task<ServiceResponse<AccountModel>> GetAccountById(int id);
        public Task<ServiceResponse<AccountModel>> GetAccountByUser(int userId);
        public Task<ServiceResponse<List<AccountModel>>> CreateAccount(CriacaoAccountDto newAccount);
        public Task<ServiceResponse<List<AccountModel>>> EditAccount(EdicaoAccountDto editAccount);
        public Task<ServiceResponse<List<AccountModel>>> RemoveAccount (int id);
        public Task<ServiceResponse<AccountModel>> DepositAccount(int id, double value);
        public Task<ServiceResponse<AccountModel>> WithdrawAccount(int id, double value);
     }
}
