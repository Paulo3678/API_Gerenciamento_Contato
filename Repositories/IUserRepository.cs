using GerenciamentoContatos.Data.Dtos;

namespace GerenciamentoContatos.Repositories
{
    public interface IUserRepository
    {
        public CreatedUserDto Add(CreateNewUserDto dto);
        public void Remove();
        public CreatedUserDto GetById(Guid id);
        public CreatedUserDto GetByEmail(string email);
        public CreatedWithPasswordUserDto GetByEmailWithPassword(string email);

    }
}
