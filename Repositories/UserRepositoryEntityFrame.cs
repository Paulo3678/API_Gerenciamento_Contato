using GerenciamentoContatos.Data;
using GerenciamentoContatos.Data.Dtos;
using GerenciamentoContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoContatos.Repositories
{
    public class UserRepositoryEntityFrame : IUserRepository
    {
        private GerenciamentoContatosContext _context;

        public UserRepositoryEntityFrame(GerenciamentoContatosContext context)
        {
            _context = context;
        }

        public CreatedUserDto Add(CreateNewUserDto dto)
        {
            string hashPassword = PasswordHasher.Encode(dto.Password);
            dto.Password = hashPassword;

            try
            {
                User user = new User()
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = hashPassword
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return new CreatedUserDto(user);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao cadastrar usuario");
            }
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public CreatedUserDto GetById(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            CreatedUserDto dto = new CreatedUserDto(user);

            return dto;
        }
    }
}
