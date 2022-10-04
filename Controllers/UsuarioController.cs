using AluraBackEnd1.Data.DTO;
using AluraBackEnd1.Models;
using AluraBackEnd1.Services;
using AluraBackEnd1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AluraBackEnd1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private ILoginService _loginService;

        public UsuarioController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("CriarLogin")]
        public async Task<IActionResult> CriarLogin([FromBody] DadosLogin login)
        {
            try
            {
                await _loginService.Insert(login);
                return Ok(login);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Logar")]
        public async Task<IActionResult> Logar(string email, string senha)
        {
            try
            {
                if(!await _loginService.SenhaCorreta(email, senha))
                {
                    return NotFound();
                }

                return Ok(_loginService.GerarToken(email));
            }

            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}
