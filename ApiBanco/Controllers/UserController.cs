using ApiBanco.Interface;
using ApiBanco.Models;
using ApiBanco.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace ApiBanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> GetAllUsers()
        {
            var users = await _userInterface.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<ServiceResponse<UserModel>>> GetUserById(int id)
        {
            var user = await _userInterface.GetUserById(id);
            return Ok(user);
        }

    }
}
