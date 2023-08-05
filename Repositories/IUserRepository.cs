using GerenciamentoContatos.Data.Dtos;

namespace GerenciamentoContatos.Repositories
{
    public interface IUserRepository
    {
        public CreatedUserDto Add(CreateNewUserDto dto);
        public void Remove();


    }
}
