using GerenciamentoContatos.Data;
using GerenciamentoContatos.Data.Dtos;
using GerenciamentoContatos.Models;

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
    }
}
