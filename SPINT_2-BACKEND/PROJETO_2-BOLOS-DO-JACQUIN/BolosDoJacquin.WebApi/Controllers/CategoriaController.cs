using BolosDoJacquin.WebApi.DTO;
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

    /// <summary>
    /// Cadastrar
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CategoriaCadastrarDTO dto)
    {
        try
        {
            var categoria = new Categoria
            {
                NomeCategoria = dto.NomeCategoria,
                Ncm = dto.NCM,
                DataCadastro = DateTime.Now
            };
            await _categoria.Cadastrar(categoria);
            return StatusCode(201, categoria);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Listar
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        try
        {
            var categoria = await _categoria.Listar();
            return Ok(categoria);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }


    /// <summary>
    /// Buscar por Id
    /// </summary>
    /// <param name="IdCategoria"></param>
    /// <returns></returns>
    [HttpGet("{IdCategoria:guid}")]
    public async Task<IActionResult> BuscarPorId(Guid IdCategoria)
    {
        try
        {
            var categoriaBuscada = await _categoria.BuscarPorId(IdCategoria);
            if (categoriaBuscada == null)
            {
                return NotFound("Categoria não encontrada! Verifique o Id e tente novamente.");
            }
            return Ok(categoriaBuscada);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Buscar por NCM
    /// </summary>
    /// <param name="NCM"></param>
    /// <returns></returns>
    [HttpGet("{NCM}")]
    public async Task<IActionResult> BuscarPorNCM(string NCM)
    {
        try
        {
            var ncmBuscado = await _categoria.BuscarPorNCM(NCM);
            if (ncmBuscado == null)
            {
                return NotFound("NCM não encontrado! Verifique o NCM e tente novamente.");
            }
            return Ok(ncmBuscado);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPatch("{IdCategoria:guid}")]
    public async Task<IActionResult> Atualizar(Guid IdCategoria, [FromBody] CategoriaAtualizarDTO dto)
    {
        var categoriaExistente = await _categoria.BuscarPorId(IdCategoria);

        categoriaExistente.NomeCategoria = dto.NomeCategoria != null ? dto.NomeCategoria : categoriaExistente.NomeCategoria;
        categoriaExistente.Ncm = dto.NCM != null ? dto.NCM : categoriaExistente.Ncm;
        categoriaExistente.DataAtualizacao = dto.NomeCategoria != null || dto.NCM != null ? DateTime.Now : categoriaExistente.DataAtualizacao;

        await _categoria.Atualizar(IdCategoria, categoriaExistente);
        return Ok(categoriaExistente);
    }
}
