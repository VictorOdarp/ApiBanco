using ApiBanco.Dto.Account;
using ApiBanco.Dto.User;
using ApiBanco.Services;

namespace ApiBanco.Interface
{
    public interface IUserInterface 
    {
        public Task<ServiceResponse<List<UserService>>> GetAllUsers();
        public Task<ServiceResponse<UserService>> GetUserById(int id);
        public Task<ServiceResponse<UserService>> GetUserByIdAccount(int idAccount);
        public Task<ServiceResponse<List<UserService>>> CreateUser(CriacaoUserDto newUser);
        public Task<ServiceResponse<List<UserService>>> EditUser(EdicaoUserDto editUser);
        public Task<ServiceResponse<List<UserService>>> DeleteUser(int id);
    }
}
