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

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] UsuarioDTOCadastro DTO)
    {
        try
        {
            var usuario = new Usuario
            {
                Nome = DTO.nomeCadastrar,
                Email = DTO.emailCadastrar,
                Senha = DTO.senhaCadastrar, // Obs.: A criptografia ocorre dentro do Repository
                IdTipoUsuario = DTO.IdTipoUsuario
            };

            await _usuario.Cadastrar(usuario);
            return StatusCode(201, usuario);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }

    }

    [HttpPatch("{Id:guid}")]
    public async Task<IActionResult> Atualizar(Guid Id, [FromBody] UsuarioDTOAtualizar DTO)
    {
        var usuarioExistente = await _usuario.BuscarPorId(Id);

        
        if (DTO.nomeAtualizar != null)
        {
            usuarioExistente.Nome = DTO.nomeAtualizar;
        }

        if (DTO.senhaAtualizar != null)
        {
            usuarioExistente.Senha = DTO.senhaAtualizar;
        }

        if (DTO.emailAtualizar != null)
        {
            usuarioExistente.Email = DTO.emailAtualizar;
        }

        if (DTO.IdTipoUsuario != null)
        {
            usuarioExistente.IdTipoUsuario = DTO.IdTipoUsuario;
        }

        await _usuario.Atualizar(Id, usuarioExistente);

        return Ok(usuarioExistente);
    }


    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> BuscarPorId(Guid Id)
    {
        try
        {
            var usuarioBuscado = await _usuario.BuscarPorId(Id);
            if(usuarioBuscado == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(usuarioBuscado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{Id:guid}")]

    public async Task<IActionResult> Deletar(Guid Id)
    {
        await _usuario.Deletar(Id);
        return NoContent();
    }
}
