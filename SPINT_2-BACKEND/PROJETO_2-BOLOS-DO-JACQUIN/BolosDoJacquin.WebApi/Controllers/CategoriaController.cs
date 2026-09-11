using BolosDoJacquin.WebApi.Interfaces;
using BolosDoJacquin.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolosDoJacquin.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoria _categoria;
    public CategoriaController (ICategoria categoria)
    {
        _categoria = categoria;
    }

    [HttpPost]
    public async Task <IActionResult> Cadastrar (Categoria categoria)
    {
        try
        {
            await _categoria.Cadastrar(categoria);
            return StatusCode(201, categoria);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }
}
