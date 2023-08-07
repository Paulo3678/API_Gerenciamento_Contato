using GerenciamentoContatos.Data.Dtos;

namespace GerenciamentoContatos.Models
{
    public interface ITokenManager
    {
        public string Generate(CreatedUserDto dto);
        public bool Validate(string token);
        public void Decode();
    }
}
