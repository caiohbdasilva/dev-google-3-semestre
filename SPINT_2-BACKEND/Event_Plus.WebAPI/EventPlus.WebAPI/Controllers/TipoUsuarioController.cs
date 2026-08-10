using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuario _tipoUsuario;
        public TipoUsuarioController(ITipoUsuario tipoUsuario)
        {
            _tipoUsuario = tipoUsuario;
        }


        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> BuscarPorId(Guid Id)
        {
            try
            {
                var tipoUsuarioBuscado = await _tipoUsuario.BuscarPorId(Id);
                if (tipoUsuarioBuscado == null)
                {
                    return NotFound("Tipo de usuário não encontrado.");                       
                }
                    
                return Ok(tipoUsuarioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os perfis de usuário cadastrados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var tipos = await _tipoUsuario.Listar();

                return Ok(tipos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        
        /// <summary>
        /// Cadastra um novo perfil de usuário
        /// </summary>
        /// <param name="tipoUsuario">Perfil do usuário a ser cadastrado</param>
        /// <returns></returns>
       [HttpPost]
       public async Task<IActionResult> Cadastrar([FromBody] TipoUsuarioDTO DTO)
        {
            var tipoUsuario = new TipoUsuario
            {
                TituloUsuario = DTO.TituloTipoUsuario
            };

            await _tipoUsuario.Cadastrar(tipoUsuario);

            return StatusCode(201, tipoUsuario);
        }



        [HttpPut("{Id:guid}")]
        public async Task<IActionResult> Atualizar(Guid Id, [FromBody] TipoUsuarioDTO DTO)
        {
            var tipoUsuario = new TipoUsuario
            {
                TituloUsuario = DTO.TituloTipoUsuario
            };

            await _tipoUsuario.Atualizar(Id, tipoUsuario);

            return Ok(tipoUsuario);
        }

        /// <summary>
        /// Remove um perfil de usuário pelo Id
        /// </summary>
        /// <param name="Id">Id do perfil a ser removido</param>
        /// <returns></returns>
        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> Deletar(Guid Id)
        {
            await _tipoUsuario.Deletar(Id);
            return NoContent();
        }
    }
}
