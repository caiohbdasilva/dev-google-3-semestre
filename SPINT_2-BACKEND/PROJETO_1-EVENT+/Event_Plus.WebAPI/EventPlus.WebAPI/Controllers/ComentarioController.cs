using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioController : ControllerBase
{
    private readonly IComentario _comentario;
    private readonly IModerationService _moderationService;

    public ComentarioController(IComentario comentario, IModerationService moderationService)
    {
        _comentario = comentario;
        _moderationService = moderationService;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        try
        {
            var comentario = await _comentario.Listar();
            return Ok(comentario);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] ComentarioDTO dto)
    {
        //Implementar a lógica de moderador de conteúdo
        try
        {
            bool reprovado = await _moderationService.ModerarTexto(dto.Descricao);

            var comentario = new Comentario()
            {
                IdEvento = dto.IdEvento,
                IdUsuario = dto.IdUsuario,
                DescricaoComentario = dto.Descricao,
                DataComentario = DateTime.Now,
                Exibe = !reprovado
            };

            await _comentario.Cadastrar(comentario);
            return StatusCode(201, comentario);
        }

        catch (Exception e)
        {
            return BadRequest(e.Message);
         
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> BuscarPorId(Guid id)
    {
        try
        {
            var comentario = await _comentario.BuscarPorId(id);
            return Ok(comentario);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("ListarPorEvento/{id:guid}")]
    public async Task<IActionResult> ListarPorEvento(Guid id)
    {
        try
        {
            var comentarioListado = await _comentario.ListarPorEvento(id);
            return Ok(comentarioListado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Deletar(Guid id)
    {
        await _comentario.Deletar(id);
        return NoContent();
    }
}