using ApiBanco.Data;
using ApiBanco.Dto.User;
using ApiBanco.Interface;
using ApiBanco.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBanco.Services
{
    public class UserService : IUserInterface
    {
        public readonly AppBankDbContext _context;

        public UserService(AppBankDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<UserModel>>> GetAllUsers()
        {
            ServiceResponse<List<UserModel>> responseModel = new ServiceResponse<List<UserModel>>();

            try
            {
                if (_context.Users.Count() == 0) 
                {
                    responseModel.Data = null;
                    responseModel.Message = "No data found";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = await _context.Users.ToListAsync();
                responseModel.Message = "List of users found!";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public Task<ServiceResponse<UserModel>> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UserModel>> GetUserByIdAccount(int accountId)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<List<UserModel>>> CreateUser(CriacaoUserDto newUser)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<UserModel>>> EditUser(EdicaoUserDto editUser)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<UserModel>>> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

    }
}
