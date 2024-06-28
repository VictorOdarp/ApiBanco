using ApiBanco.Enums;
using ApiBanco.Models;

namespace ApiBanco.Dto.Account
{
    public class EdicaoAccountDto
    {
        public int Id { get; set; }
        public UserModel Holder { get; set; }
        public AccountType AccountType { get; set; }
        public double Balance { get; set; }
        public double Limit { get; set; }
        public bool Status { get; set; }
    }
}
