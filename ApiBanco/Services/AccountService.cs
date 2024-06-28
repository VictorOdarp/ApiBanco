using ApiBanco.Data;
using ApiBanco.Dto.Account;
using ApiBanco.Interface;
using ApiBanco.Models;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using MySqlConnector;

namespace ApiBanco.Services
{
    public class AccountService : IAccountInterface
    {
        public readonly AppBankDbContext _context;

        public AccountService(AppBankDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<AccountModel>>> GetAllAccounts()
        {
            ServiceResponse<List<AccountModel>> responseModel = new ServiceResponse<List<AccountModel>>();

            try
            {
                if (!_context.Accounts.Any())
                {
                    responseModel.Data = null;
                    responseModel.Message = "No data found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = await _context.Accounts.Include(user => user.Holder).ToListAsync();
                responseModel.Message = "All accounts have been collected!";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ServiceResponse<AccountModel>> GetAccountById(int id)
        {
            ServiceResponse<AccountModel> responseModel = new ServiceResponse<AccountModel>();

            try
            {
                AccountModel account = await _context.Accounts.Include(bancoAccount => bancoAccount.Holder).FirstOrDefaultAsync(x => x.Id == id);

                if (account == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "No account found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = account;
                responseModel.Message = "Account found!";
                return responseModel;
            }

            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ServiceResponse<AccountModel>> GetAccountByUser(int userId)
        {
            ServiceResponse<AccountModel> respondeModel = new ServiceResponse<AccountModel>();

            try
            {
                AccountModel account = await _context.Accounts.Include(bancoAccounts => bancoAccounts.Holder).Where(bancoAccounts => bancoAccounts.Holder.Id == userId).FirstOrDefaultAsync();

                if(account == null)
                {
                    respondeModel.Data = null;
                    respondeModel.Message = "No accounts found by the informed user!";
                    respondeModel.Status = false;
                    return respondeModel;
                }

                respondeModel.Data = account;
                respondeModel.Message = "Account Found!";
                return respondeModel; 
            }
            catch (Exception ex)
            {
                respondeModel.Message = ex.Message;
                respondeModel.Status = false;
                return respondeModel;
            }
        }

        public async Task<ServiceResponse<List<AccountModel>>> CreateAccount(CriacaoAccountDto newAccount)
        {
            ServiceResponse<List<AccountModel>> responseModel = new ServiceResponse<List<AccountModel>>();

            try
            {
                UserModel holder = await _context.Users.FirstOrDefaultAsync(bancoHolders => bancoHolders.Id == newAccount.Holder.Id);

                if (holder == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Owner not found to create account!";
                    responseModel.Status = false;
                    return responseModel;
                }

                var account = new AccountModel()
                {
                    Holder = holder,
                    AccountType = newAccount.AccountType,
                    Balance = newAccount.Balance,
                    Status = newAccount.Status,
                };

                if (account.Balance < 5000)
                {
                    account.Limit = 200;
                }

                _context.Add(account);
                await _context.SaveChangesAsync();

                responseModel.Data = await _context.Accounts.Include(holders => holders.Holder).ToListAsync();
                responseModel.Message = "Account created successfully!";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        } 

        public Task<ServiceResponse<List<AccountModel>>> EditAccount(EdicaoAccountDto editAccount)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<AccountModel>>> RemoveAccount(int id)
        {
            throw new NotImplementedException();
        }
    }
}
