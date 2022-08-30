using AluraBackEnd1.Data;
using AluraBackEnd1.Models;
using AluraBackEnd1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AluraBackEnd1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceitaController : ControllerBase
    {
        private IReceitaService _receitaService;

        public ReceitaController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        [HttpPost]
        public async Task<IActionResult> PostReceita([FromBody] Receita receita)
        {
            try
            {
                if (_receitaService.HasReceitaNoMesComAMesmaDescricao(receita))
                    throw new Exception("Item já adicionado no mês");

                await _receitaService.Insert(receita);
                return Ok(receita);
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetReceitas()
        {
            try
            {
                return Ok(await _receitaService.AllReceitas());
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetReceita(int id)
        {
            try
            {
                Receita item = await _receitaService.GetById(id);

                if (item == null)
                    throw new Exception("Item não encontrado");

                return Ok(item);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> PutReceita(int id, [FromBody] Receita receita)
        {
            try
            {
                if (_receitaService.HasReceitaNoMesComAMesmaDescricao(receita))
                    throw new Exception("Item já adicionado no mês");

                await _receitaService.Update(receita, id);
                return Ok(receita);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
