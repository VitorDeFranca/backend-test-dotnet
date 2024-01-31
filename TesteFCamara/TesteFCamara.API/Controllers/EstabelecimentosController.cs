using Microsoft.AspNetCore.Mvc;
using TesteFCamara.Application.Dtos;
using TesteFCamara.Application.Dtos.Requests;
using TesteFCamara.Application.Interfaces;
using TesteFCamara.Application.Services;
using TesteFCamara.Domain.Entities;

namespace TesteFCamara.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstabelecimentosController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        private readonly IEstabelecimentoService _estabelecimentoService;

        public EstabelecimentosController(IEstabelecimentoService estabelecimentoService, IVeiculoService veiculoService)
        {
            _estabelecimentoService = estabelecimentoService;
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var estabelecimentos = await _estabelecimentoService.GetAllEstabelecimentosAsync();
                if (estabelecimentos == null) return NoContent();

                return Ok(estabelecimentos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var estabelecimento = await _estabelecimentoService.GetEstabelecimentoByIdAsync(id);
                if (estabelecimento == null) return NotFound();

                return Ok(estabelecimento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsercaoEdicaoEstabelecimentoRequest model)
        {
            try
            {
                var estabelecimento = InsercaoEdicaoEstabelecimentoRequest.ConverterParaEntidade(model);
                if (estabelecimento == null) return BadRequest();

                var estabelecimentoRetorno = await _estabelecimentoService.AddEstabelecimento(estabelecimento);

                return CreatedAtAction(nameof(GetById), new { id = estabelecimento.Id}, estabelecimento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, InsercaoEdicaoEstabelecimentoRequest model)
        {
            try
            {
                var estabelecimento = InsercaoEdicaoEstabelecimentoRequest.ConverterParaEntidade(model);

                var estabelecimentoRetorno = await _estabelecimentoService.UpdateEstabelecimento(id, estabelecimento);
                if (estabelecimentoRetorno == null) return NotFound();

                return Ok(estabelecimentoRetorno);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var estabelecimento = await _estabelecimentoService.GetEstabelecimentoByIdAsync(id, true);
                if (estabelecimento == null) return NotFound();

                return await _estabelecimentoService.DeleteEstabelecimento(id) 
                    ? Ok(new {message = "Deletado com sucesso"})
                    : throw new Exception("Ocorreu um erro não específico ao tentar deletar o estabelecimento");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}/Veiculos")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var veiculos = await _veiculoService.GetVeiculosByEstabelecimentoIdAsync(id);
                if (veiculos == null) return NoContent();

                return Ok(veiculos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}/Veiculos/{veiculoId}")]
        public async Task<IActionResult> GetById(int id, int veiculoId)
        {
            try
            {
                var veiculo = await _veiculoService.GetVeiculoByIdAsync(id, veiculoId);
                if (veiculo == null) return NotFound();

                return Ok(veiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("{id}/Veiculos")]
        public async Task<IActionResult> Post(int id, InsercaoVeiculoRequest model)
        {
            try
            {
                var veiculo = InsercaoVeiculoRequest.ConverterParaEntidade(id, model);
                if (veiculo == null) return BadRequest();

                var veiculoRetorno = await _veiculoService.AddVeiculo(id, veiculo);

                return CreatedAtAction(nameof(GetById), new { id = veiculoRetorno.Id }, veiculoRetorno);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/Veiculos/{veiculoId}")]
        public async Task<IActionResult> Put(int id, int veiculoId, EdicaoVeiculoRequest model)
        {
            try
            {
                var veiculo = EdicaoVeiculoRequest.ConverterParaEntidade(id, model);
                if (veiculo == null) return NotFound();
                veiculo.Id = veiculoId;

                var veiculoRetorno = await _veiculoService.UpdateVeiculo(id, veiculo);

                return Ok(veiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}/Veiculos/{veiculoId}")]
        public async Task<IActionResult> Delete(int id, int veiculoId)
        {
            try
            {
                var veiculo = await _veiculoService.GetVeiculoByIdAsync(id, veiculoId);
                if (veiculo == null) return NotFound();

                return await _veiculoService.DeleteVeiculo(id, veiculoId)
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
