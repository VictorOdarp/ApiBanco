using ApiBanco.Data;
using ApiBanco.Dto.User;
using ApiBanco.Interface;

namespace ApiBanco.Services
{
    public class UserService : IUserInterface
    {
        public readonly AppBankDbContext _context;

        public UserService(AppBankDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<UserService>>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UserService>> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UserService>> GetUserByIdAccount(int accountId)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<List<UserService>>> CreateUser(CriacaoUserDto newUser)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<UserService>>> EditUser(EdicaoUserDto editUser)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<UserService>>> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

    }
}
