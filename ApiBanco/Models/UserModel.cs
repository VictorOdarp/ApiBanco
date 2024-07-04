using System.ComponentModel.DataAnnotations;

namespace ApiBanco.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Cpf { get; set; }
        public int AccountId { get; set; }
        public AccountModel Account { get; set; }

    }
}
