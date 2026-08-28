using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private readonly IEvento _evento;
    private readonly IClaudinaryService _claudinary;

    public EventoController(IEvento evento, IClaudinaryService claudinary)
    {
        _evento = evento;
        _claudinary = claudinary;
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Cadastrar([FromForm] EventoDTOCadastrar DTO)
    {
        try
        {
            string? ImagemUrl = null;

            if (DTO.ArquivoImagem is not null)
            {
                ImagemUrl = await _claudinary.UploadImagem(DTO.ArquivoImagem);
            }
            var evento = new Evento
            {
                NomeEvento = DTO.Nome,
                DescricaoEvento = DTO.Descricao,
                DataEvento = DTO.DataEvento,
                Urlimagem = ImagemUrl, //URL vinda do Cloudinary (ou null caso não tenha sido enviado arquivo)
                IdTipoEvento = DTO.IdTipoEvento,
                IdInstituicao = DTO.IdInstituicao
            };
            await _evento.Cadastrar(evento);
            return StatusCode(201, evento);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPatch("{Id:guid}")]
    [Consumes("multipart/form-data")]

    public async Task<IActionResult> Atualizar(Guid Id, [FromForm] EventoDTOAtualizar DTO)
    {
        try
        {
            string? ImagemUrl = null;
            if (DTO.ArquivoImagem is not null)
            {
                ImagemUrl = _claudinary.UploadImagem(DTO.ArquivoImagem).Result;
            }
            var eventoExistente = await _evento.BuscarPorId(Id);

            if (DTO.Nome != null)
            {
                eventoExistente.NomeEvento = DTO.Nome;
            }
            if (DTO.Descricao != null)
            {
                eventoExistente.DescricaoEvento = DTO.Descricao;
            }
            if (DTO.DataEvento != null)
            {
                eventoExistente.DataEvento = DTO.DataEvento.Value;
            }
            if (DTO.IdTipoEvento != null)
            {
                eventoExistente.IdTipoEvento = DTO.IdTipoEvento;
            }
            if (DTO.IdInstituicao != null)
            {
                eventoExistente.IdInstituicao = DTO.IdInstituicao;
            }

            await _evento.Atualizar(Id, eventoExistente);
            return Ok(eventoExistente);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        try
        {
            var eventos = await _evento.Listar();
            return Ok(eventos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> BuscarPorId(Guid Id)
    {
        try
        {
            var eventoBuscado = await _evento.BuscarPorId(Id);
            if (eventoBuscado == null)
            {
                return NotFound("Evento não encontrado!");
            }
            return Ok(eventoBuscado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete ("{Id:guid}")]
    public async Task<IActionResult> Deletar (Guid Id)
    {
        await _evento.Deletar(Id);
        return NoContent();
    }

    [HttpGet("usuario/{idUsuario:guid}")]
    public async Task<IActionResult> ListarPorInscrito(Guid idUsuario)
    {
        var eventos = await _evento.ListarPorInscrito(idUsuario);
        return Ok(eventos);
    }

    [HttpGet("instituicao/{idInstituicao:guid}")]
    public async Task<IActionResult> ListarPorInstituicao(Guid idInstituicao)
    {
        var eventos = await _evento.ListarPorInstituicao(idInstituicao);
        return Ok(eventos);
    }

    [HttpGet("proximo")]
    public async Task <IActionResult> ListarProximoEvento()
    {
        try
        {
            var eventos = await _evento.ListarProximoEvento();
            return Ok(eventos);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

}
