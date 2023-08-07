using GerenciamentoContatos.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoContatos.Controllers;

[Controller]
[Route("[Controller]")]
public class EnrollmentController : ControllerBase
{

    [HttpPost]
    public IActionResult Create(CreateNewEnrollment dto)
    {
        return Ok(new { message = "Passou" });
    }
}
