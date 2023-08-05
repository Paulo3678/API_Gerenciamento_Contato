using GerenciamentoContatos.Models;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoContatos.Data.Dtos
{
    public class CreatedUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }   
        public DateTime DateOfCreation { get; set; }
        public CreatedUserDto(User user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.Email = user.Email;
            this.DateOfCreation = user.DateOfCreation;
        }
    }
}
