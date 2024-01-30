using Microsoft.AspNetCore.Mvc;
using TesteFCamara.Application.Interfaces;
using TesteFCamara.Application.Services;
using TesteFCamara.Domain.Entities;

namespace TesteFCamara.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculosController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int estabelecimentoId)
        {
            try
            {
                var veiculos = await _veiculoService.GetVeiculosByEstabelecimentoIdAsync(estabelecimentoId);
                if (veiculos == null) return NoContent();

                return Ok(veiculos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int estabelecimentoId,int id)
        {
            try
            {
                var veiculo = await _veiculoService.GetVeiculoByIdAsync(estabelecimentoId, id);
                if (veiculo == null) return NotFound();

                return Ok(veiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(int estabelecimentoId,Veiculo model)
        {
            try
            {
                var veiculo = await _veiculoService.AddVeiculo(estabelecimentoId ,model);
                if (veiculo == null) return BadRequest();

                return CreatedAtAction(nameof(GetById), new { id = veiculo.Id }, veiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{estabelecimentoId}")]
        public async Task<IActionResult> Put(int estabelecimentoId, Veiculo model)
        {
            try
            {
                var veiculo = await _veiculoService.UpdateVeiculo(estabelecimentoId, model);
                if (veiculo == null) return NotFound();

                return Ok(veiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int estabelecimentoId, int id)
        {
            try
            {
                var veiculo = await _veiculoService.GetVeiculoByIdAsync(estabelecimentoId, id);
                if (veiculo == null) return NotFound();

                return await _veiculoService.DeleteVeiculo(estabelecimentoId, id)
                    ? Ok(new { message = "Deletado com sucesso" })
                    : throw new Exception("Ocorreu um erro não específico ao tentar deletar o estabelecimento");
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
