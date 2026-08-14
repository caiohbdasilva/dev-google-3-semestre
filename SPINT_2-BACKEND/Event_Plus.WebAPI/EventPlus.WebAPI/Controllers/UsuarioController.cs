using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuario _usuario;

    public UsuarioController(IUsuario usuario)
    {
        _usuario = usuario;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        try
        {
            var usuarios = await _usuario.Listar();
            return Ok(usuarios);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    public async Task<IActionResult> Cadastrar([FromBody] UsuarioDTO DTO)
    {
        try
        {
            var usuario = new Usuario
            {
                Nome = DTO.NomeUsuario,
                Email = DTO.EmailUsuario,
                Senha = DTO.SenhaUsuario
            };

            await _usuario.Cadastrar(usuario);
            return StatusCode(201, usuario);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
