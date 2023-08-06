using GerenciamentoContatos.Data.Dtos;
using GerenciamentoContatos.Models;
using GerenciamentoContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoContatos.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private IUserRepository _repository;
    private ITokenManager _tokenManager;
    public UserController(IUserRepository repository, ITokenManager tokenManager)
    {
        _repository = repository;
        _tokenManager = tokenManager;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateNewUserDto dto)
    {
        try
        {
            CreatedUserDto user = _repository.Add(dto);

            return Ok(user);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
