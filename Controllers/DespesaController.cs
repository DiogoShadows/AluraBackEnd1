using AluraBackEnd1.Data.DTO;
using AluraBackEnd1.Models;
using AluraBackEnd1.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluraBackEnd1.Controllers
{
    [ApiController]
    [Route("[controller]"), Authorize]
    public class DespesaController : ControllerBase
    {
        private IDespesaService _despesaService;

        public DespesaController(IDespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        [HttpPost]
        public async Task<IActionResult> PostDespesa([FromBody] InserirDespesaDTO despesa)
        {
            try
            {
                if (_despesaService.HasDespesaNoMesComAMesmaDescricao(despesa))
                    throw new Exception("Item já adicionado no mês");

                await _despesaService.Insert(despesa);
                return Ok(despesa);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDespesas(string? descricao)
        {
            try
            {
                return Ok(await _despesaService.AllDespesas(descricao));
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{ano}/{mes}")]
        public async Task<IActionResult> GetDespesasByMes(int ano, int mes)
        {
            try
            {
                return Ok(await _despesaService.DespesasByMes(ano, mes));
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDespesa(int id)
        {
            try
            {
                InserirDespesaDTO item = await _despesaService.GetById(id);

                if (item == null)
                    throw new Exception("Item não encontrado");

                return Ok(item);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDespesa(int id, [FromBody] InserirDespesaDTO despesa)
        {
            try
            {
                if (_despesaService.HasDespesaNoMesComAMesmaDescricao(despesa))
                    throw new Exception("Item já adicionado no mês");

                await _despesaService.Update(despesa, id);
                return Ok(despesa);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespesa(int id)
        {
            try
            {
                await _despesaService.Delete(id);
                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
