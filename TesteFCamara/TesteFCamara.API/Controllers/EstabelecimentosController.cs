using Microsoft.AspNetCore.Mvc;
using TesteFCamara.Application.Dtos;
using TesteFCamara.Application.Interfaces;
using TesteFCamara.Application.Services;
using TesteFCamara.Domain.Entities;

namespace TesteFCamara.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstabelecimentosController : ControllerBase
    {
        private readonly IEstabelecimentoService _estabelecimentoService;

        public EstabelecimentosController(IEstabelecimentoService estabelecimentoService)
        {
            _estabelecimentoService = estabelecimentoService;
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
        public async Task<IActionResult> Post(Estabelecimento model)
        {
            try
            {
                var estabelecimento = await _estabelecimentoService.AddEstabelecimento(model);
                if (estabelecimento == null) return BadRequest();

                return CreatedAtAction(nameof(GetById), new { id = estabelecimento.Id}, estabelecimento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Estabelecimento model)
        {
            try
            {
                var estabelecimento = await _estabelecimentoService.UpdateEstabelecimento(model.Id, model);
                if (estabelecimento == null) return NotFound();

                return Ok(estabelecimento);
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


    }
}
