using ApiBanco.Dto.Account;
using ApiBanco.Dto.User;
using ApiBanco.Models;
using ApiBanco.Services;

namespace ApiBanco.Interface
{
    public interface IUserInterface 
    {
        public Task<ServiceResponse<List<UserModel>>> GetAllUsers();
        public Task<ServiceResponse<UserModel>> GetUserById(int id);
        public Task<ServiceResponse<AccountModel>> GetUserByIdAccount(int accountId);
        public Task<ServiceResponse<List<UserModel>>> CreateUser(CriacaoUserDto newUser);
        public Task<ServiceResponse<List<UserModel>>> EditUser(EdicaoUserDto editUser);
        public Task<ServiceResponse<List<UserModel>>> DeleteUser(int id);
    }
}
