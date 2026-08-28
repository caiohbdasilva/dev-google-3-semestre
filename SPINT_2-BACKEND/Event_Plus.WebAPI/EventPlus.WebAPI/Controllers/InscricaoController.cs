using EventPlus.WebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InscricaoController : ControllerBase
{
    private readonly IInscricao _inscricao;
    

    public InscricaoController(IInscricao inscricao)
    {
        _inscricao = inscricao;
    }

    [HttpGet]
    public async Task <IActionResult> Listar()
    {
        try
        {
            var inscricao = await _inscricao.Listar();
            return Ok(inscricao);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }
}
