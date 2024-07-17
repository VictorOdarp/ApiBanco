using ApiBanco.Data;
using ApiBanco.Dto.User;
using ApiBanco.Interface;
using ApiBanco.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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

        public async Task<ServiceResponse<UserModel>> GetUserById(int id)
        {
            ServiceResponse<UserModel> responseModel = new ServiceResponse<UserModel>();

            try
            {
                UserModel user = await _context.Users.FirstOrDefaultAsync(bancoUsers => bancoUsers.Id == id);

                if (user == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "No User found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = user;
                responseModel.Message = "User found!";
                return responseModel;

            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ServiceResponse<AccountModel>> GetUserByIdAccount(int accountId)
        {
            ServiceResponse<AccountModel> responseModel = new ServiceResponse<AccountModel>();

            try
            {
                AccountModel user = await _context.Accounts.Include(holder => holder.Holder).Where(bancoAccount => bancoAccount.Id == accountId).FirstOrDefaultAsync();

                if (user == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Not user with a ID Account informed found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = user;
                responseModel.Message = "User by ID Account found!";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
         }
        public async Task<ServiceResponse<List<UserModel>>> CreateUser(CriacaoUserDto newUser)
        {
            ServiceResponse<List<UserModel>> responseModel = new ServiceResponse<List<UserModel>>();

            try
            {
                UserModel user = new UserModel
                {
                    Name = newUser.Name,
                    Surname = newUser.Surname,
                    Cpf = newUser.Cpf,
                };

                _context.Add(user);
                await _context.SaveChangesAsync();

                responseModel.Data = await _context.Users.ToListAsync();
                responseModel.Message = "User created successfuly";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ServiceResponse<List<UserModel>>> EditUser(EdicaoUserDto editUser)
        {
            ServiceResponse<List<UserModel>> responseModel = new ServiceResponse<List<UserModel>>();

            try
            {
                UserModel user = await _context.Users.FirstOrDefaultAsync(bancoUser => bancoUser.Id == editUser.Id);

                if(user == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Not user found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                user.Name = editUser.Name;
                user.Surname = editUser.Surname;
                user.Cpf = editUser.Cpf;

                _context.Update(user);
                await _context.SaveChangesAsync();

                responseModel.Data = await _context.Users.ToListAsync();
                responseModel.Message = "User edit successfuly";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ServiceResponse<List<UserModel>>> DeleteUser(int id)
        {
            ServiceResponse<List<UserModel>> responseModel = new ServiceResponse<List<UserModel>>();

            try
            {
                UserModel user = await _context.Users.FirstOrDefaultAsync(bancoUser => bancoUser.Id == id);

                if (user == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Not user found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                _context.Remove(user);
                await _context.SaveChangesAsync();

                responseModel.Data = await _context.Users.ToListAsync();
                responseModel.Message = "User removed successfuly";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

    }
}
