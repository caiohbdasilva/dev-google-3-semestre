using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
         private readonly ITipoEvento _tipoEvento;

         public TipoEventoController(ITipoEvento tipoEvento)
         {
           _tipoEvento = tipoEvento;           
         }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var tipos = await _tipoEvento.Listar();
                return Ok(tipos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="tipoEvento">Perfil do evento a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] TipoEventoDTO DTO)
        {
            var tipoEvento = new TipoEvento
            {
                TituloEvento = DTO.TituloTipoEvento
            };

            await _tipoEvento.Cadastrar(tipoEvento);
            return StatusCode(201, tipoEvento);
        }
    }
}
