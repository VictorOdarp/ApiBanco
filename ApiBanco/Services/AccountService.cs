using ApiBanco.Data;
using ApiBanco.Dto.Account;
using ApiBanco.Interface;
using ApiBanco.Models;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;

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
                responseModel.Message = "Todas as contas foram coletadas!";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public Task<ServiceResponse<AccountModel>> GetAccountById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<AccountModel>> GetAccountByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<AccountModel>>> CreateAccount(CriacaoAccountDto newAccount)
        {
            throw new NotImplementedException();
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
