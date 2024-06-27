using ApiBanco.Data;
using ApiBanco.Dto.User;
using ApiBanco.Interface;
using ApiBanco.Models;

namespace ApiBanco.Services
{
    public class UserService : IUserInterface
    {
        public readonly AppBankDbContext _context;

        public UserService(AppBankDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<UserModel>>> GetAllUsers()
        {
            throw new NotImplementedException();
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
