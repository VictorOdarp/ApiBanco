using ApiBanco.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiBanco.Models
{
    public class AccountModel
    {
        [Key]
        public int Id { get; set; }
        public UserModel Holder { get; set; }
        public AccountType AccountType { get; set; }
        public double Balance { get; set; }
        public double Limit { get; set; }
        public bool Status { get; set; } 
    }
}
