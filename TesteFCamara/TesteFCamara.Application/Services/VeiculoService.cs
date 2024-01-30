using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TesteFCamara.Application.Dtos;
using TesteFCamara.Application.Interfaces;
using TesteFCamara.Domain.Entities;
using TesteFCamara.Domain.Interfaces;

namespace TesteFCamara.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;
        public VeiculoService(IVeiculoRepository veiculoRepository, IEstabelecimentoRepository estabelecimentoRepository)
        {
            _veiculoRepository = veiculoRepository;
            _estabelecimentoRepository = estabelecimentoRepository;
        }
        public async Task<List<Veiculo>> GetVeiculosByEstabelecimentoIdAsync(int estabelecimentoId)
        {
            try
            {
                List<Veiculo> veiculos = await _veiculoRepository.GetAllVeiculosAsync(estabelecimentoId);
                if (veiculos == null) return null;

                /* List<VeiculoDTO> veiculosResponse = null;
                foreach (Veiculo veiculo in veiculos)
                {
                    var veiculoDTO = VeiculoDTO.ConverterParaResponse(veiculo);
                    veiculosResponse.Add(veiculoDTO);
                }*/

                return veiculos;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Veiculo> GetVeiculoByIdAsync(int estabelecimentoId, int veiculoId)
        {
            try
            {
                Veiculo veiculo = await _veiculoRepository.GetVeiculoByIdAsync(estabelecimentoId, veiculoId);
                if (veiculo == null) return null;

                //var veiculoResponse = VeiculoDTO.ConverterParaResponse(veiculo);

                return veiculo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Veiculo> AddVeiculo(int estabelecimentoId, Veiculo model)
        {
            try
            {
                Estabelecimento estabelecimento = await _estabelecimentoRepository.GetEstabelecimentoByIdAsync(estabelecimentoId);
                if (estabelecimento == null) throw new Exception("Estabelecimento não encontrado para adição de veículo");

                string tipoVeiculo = model.Tipo.ToLower();
                
                if (tipoVeiculo == "moto" && estabelecimento.QtdVagasMoto > 0 ||
                    tipoVeiculo == "carro" && estabelecimento.QtdVagasCarro > 0)
                {
                    //Veiculo veiculo = VeiculoDTO.ConverterParaEntidade(model);
                    model.EstabelecimentoId = estabelecimento.Id;

                    _veiculoRepository.Create(model);

                    if (tipoVeiculo == "moto") estabelecimento.QtdVagasMoto--;
                    if (tipoVeiculo == "carro") estabelecimento.QtdVagasCarro--;

                    if (await _veiculoRepository.SaveChangesAsync())
                    {
                        Veiculo veiculoRetorno = await _veiculoRepository.GetVeiculoByIdAsync(model.EstabelecimentoId, model.Id);

                        return veiculoRetorno;
                    }
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Veiculo> UpdateVeiculo(int estabelecimentoId, Veiculo model)
        {
            try
            {
                Estabelecimento estabelecimento = await _estabelecimentoRepository.GetEstabelecimentoByIdAsync(estabelecimentoId);
                if (estabelecimento == null) throw new Exception("Estabelecimento não encontrado para edição de veículo");

                Veiculo veiculo = await _veiculoRepository.GetVeiculoByIdAsync(model.EstabelecimentoId, model.Id);
                if (veiculo == null) return null;
                model.Id = veiculo.Id;
                //var modelEntidade = VeiculoDTO.ConverterParaEntidade(model);

                _veiculoRepository.Update(model);
                _veiculoRepository.SaveChangesAsync();

                var veiculoRetorno = await _veiculoRepository.GetVeiculoByIdAsync(estabelecimentoId, model.Id);
                return veiculoRetorno;


            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> DeleteVeiculo(int estabelecimentoId, int veiculoId)
        {
            try
            {
                Estabelecimento estabelecimento = await _estabelecimentoRepository.GetEstabelecimentoByIdAsync(estabelecimentoId);
                if (estabelecimento == null) throw new Exception("Estabelecimento não encontrado para deleção de veículo");

                Veiculo veiculo = await _veiculoRepository.GetVeiculoByIdAsync(estabelecimentoId, veiculoId);
                if (veiculo == null) throw new Exception("veiculo não encontrado para deleção");

                _veiculoRepository.Delete(veiculo);
                return await _veiculoRepository.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
