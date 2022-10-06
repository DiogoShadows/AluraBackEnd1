using AluraBackEnd1.Services;
using AluraBackEnd1.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluraBackEnd1.Controllers
{
    [ApiController]
    [Route("[controller]"), Authorize]
    public class ResumoController : ControllerBase
    {
        private IResumoService _resumoService;

        public ResumoController(IResumoService resumoService)
        {
            _resumoService = resumoService;
        }

        [HttpGet("{ano}/{mes}")]
        public async Task<IActionResult> GetResumoByMes(int ano, int mes)
        {
            try
            {
                return Ok(await _resumoService.ResumoMes(ano, mes));
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
