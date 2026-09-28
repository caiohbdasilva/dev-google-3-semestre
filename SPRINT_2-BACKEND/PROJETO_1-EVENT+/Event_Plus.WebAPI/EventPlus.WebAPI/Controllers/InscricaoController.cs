using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
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

    [HttpGet("{id:guid}")]

    public async Task<IActionResult> BuscarPorId(Guid Id)
    {
        try
        {
            var inscricaoBuscada = await _inscricao.BuscarPorId(Id);
            if (inscricaoBuscada == null)
            {
                return NotFound("Inscrição não encontrada!");
            }
            return Ok(inscricaoBuscada);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }


    [HttpPost]
    public async Task<IActionResult> Inscrever([FromBody]PresencaDTOInscricao dto)
    {
        try
        {
            var presenca = new Presenca
            {
                IdEvento = dto.IdEvento,
                IdUsuario = dto.IdUsuario,
                Situacao = true
            };

            await _inscricao.Inscrever(presenca);
            return StatusCode(201, presenca);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPut("{Id:guid}")]
    public async Task<IActionResult> AtualizarSituacao(Guid Id, [FromBody] AtualizarSituacaoDTO dto)
    {
        try
        {
            var presencaExistente = await _inscricao.BuscarPorId(Id);

            if (dto.Situacao != null)
            {
                presencaExistente.Situacao = dto.Situacao.Value; //Como no nosso BD o valor da situação esta "NOT NULL",
                //devemos realizar essa conversão para não dar erro de conversão, 
                //uma vez que nosso bool pode ser nulo na DTO (Veja o por que na anotação da DTO).
            }

            await _inscricao.AtualizarSituacao(Id, dto.Situacao.Value);
            return Ok(presencaExistente);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }

    }

}
