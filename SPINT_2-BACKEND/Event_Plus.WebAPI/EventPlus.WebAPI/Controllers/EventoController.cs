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
    public async Task<IActionResult> Cadastrar([FromForm]EventoDTO DTO)
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
}
