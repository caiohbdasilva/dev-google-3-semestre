using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{
    private readonly IInstituicao _instituicao;

    public InstituicaoController(IInstituicao instituicao)
    {
        _instituicao = instituicao;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        try
        {
            var instituicoes = await _instituicao.Listar();
            return Ok(instituicoes);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> BuscarPorId(Guid Id)
    {
        try
        {
            var instituicaoBuscada = await _instituicao.BuscarPorId(Id);
            if (instituicaoBuscada == null)
            {
                return NotFound("Instituição não cadastrada.");
            }
            return Ok(instituicaoBuscada);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] InstituicaoDTOCadastrar DTO)
    {
        try
        {
            var instituicao = new Instituicao
            {
                Cnpj = DTO.CNPJ,
                NomeFantasia = DTO.nomeFantasia,
                Endereco = DTO.endereco
            };
            await _instituicao.Cadastrar(instituicao);
            return StatusCode(201, instituicao);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch("{Id:guid}")]
    public async Task<IActionResult> Atualizar(Guid Id, [FromBody] InstituicaoDTOAtualizar DTO)
    {
        var instituicaoExistente = await _instituicao.BuscarPorId(Id);

        if (DTO.nomeFantasia != null)
        {
            instituicaoExistente.NomeFantasia = DTO.nomeFantasia;
        }
        if (DTO.endereco != null)
        {
            instituicaoExistente.Endereco = DTO.endereco;
        }
        if (DTO.CNPJ != null)
        {
            instituicaoExistente.Cnpj = DTO.CNPJ;
        }

        await _instituicao.Atualizar(Id, instituicaoExistente);

        return Ok(instituicaoExistente);
    }

    [HttpDelete("{Id:guid}")]

    public async Task<IActionResult> Deletar(Guid Id)
    {
    await _instituicao.Deletar(Id);
    return NoContent();
    }
}
