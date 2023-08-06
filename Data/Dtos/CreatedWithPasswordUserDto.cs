using GerenciamentoContatos.Models;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoContatos.Data.Dtos
{
    public class CreatedWithPasswordUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password{ get; set; }
        public DateTime DateOfCreation { get; set; }
        public CreatedWithPasswordUserDto(User user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.Email = user.Email;
            this.Password = user.Password;
            this.DateOfCreation = user.DateOfCreation;
        }
    }
}
