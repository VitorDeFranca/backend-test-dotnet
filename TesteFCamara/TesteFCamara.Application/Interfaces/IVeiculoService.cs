using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFCamara.Application.Dtos;
using TesteFCamara.Domain.Entities;

namespace TesteFCamara.Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<List<Veiculo>> GetVeiculosByEstabelecimentoIdAsync(int estabelecimentoId);
        Task<Veiculo> GetVeiculoByIdAsync(int estabelecimentoId, int veiculoId);
        Task<Veiculo> AddVeiculo(int estabelecimentoId, Veiculo model);
        Task<Veiculo> UpdateVeiculo(int estabelecimentoId, Veiculo model);
        Task<bool> DeleteVeiculo(int estabelecimentoId, int veiculoId);


    }
}
