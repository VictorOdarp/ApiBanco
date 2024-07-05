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

    }
}
