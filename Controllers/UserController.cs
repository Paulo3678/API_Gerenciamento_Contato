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

    public UserController(IUserRepository repository)
    {
        _repository = repository;
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
