using System.ComponentModel.DataAnnotations;

namespace GerenciamentoContatos.Data.Dtos;

public class CreateNewUserDto
{
    [Required(ErrorMessage = "É preciso informar o nome para continuar.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "É preciso informar o e-mail para continuar.")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Informe um e-mail válido para continuar.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "É preciso informar uma senha para continuar.")]
    [DataType(DataType.Password, ErrorMessage = "Senha informada não segue os padrões necessários.")]
    public string Password { get; set; }
    [Required(ErrorMessage = "É preciso confirmar sua senha.")]
    [Compare("Password", ErrorMessage = "As senhas não correspondem.")]
    public string ComparePassword { get; set; }
}
