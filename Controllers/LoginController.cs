using GerenciamentoContatos.Data.Dtos;
using GerenciamentoContatos.Data.Dtos.Request;
using GerenciamentoContatos.Models;
using GerenciamentoContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoContatos.Controllers;


[Controller]
[Route("[Controller]")]
public class LoginController : ControllerBase
{
    private IUserRepository _repository;
    private ITokenManager _tokenManager;
    public LoginController(IUserRepository repository, ITokenManager tokenManager)
    {
        _repository = repository;
        _tokenManager = tokenManager;
    }

    [HttpPost]
    public IActionResult Login([FromBody] UserLoginDto dto)
    {
        try
        {
            var user = _repository.GetByEmailWithPassword(dto.Email);

            if (!PasswordHasher.Verify(dto.Password, user.Password))
            {
                return Unauthorized(new UnauthorizedDto().Message = "Os dados passados não são válidos");
            }

            CreatedUserDto userDto = new CreatedUserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                DateOfCreation = user.DateOfCreation
            };

            var token = _tokenManager.Generate(userDto);

            return Ok(new { token = token });
        }
        catch (Exception e) {
            return BadRequest(new { message="Usuário inválido." }) ;
        }
    }
}
