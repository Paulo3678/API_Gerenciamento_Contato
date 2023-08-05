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

    [HttpPost("/login")]
    public IActionResult Login()
    {
        var user = _repository.GetById(new Guid("08db95f3-86c7-4ad0-8523-0dd66f4a91e8"));
        var token = _tokenManager.Generate(user);

        return Ok(token);
    }

}
