using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFCamara.Domain.Entities;

namespace TesteFCamara.Application.Dtos
{
    public class VeiculoDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Tipo { get; set; }
        public int EstabelecimentoId { get; set; }

        public VeiculoDTO(int id, string marca, string modelo, string cor, string placa, string tipo, int estabelecimentoId)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
            Placa = placa;
            Tipo = tipo;
            EstabelecimentoId = estabelecimentoId;
        }

        public static VeiculoDTO ConverterParaResponse(Veiculo veiculo)
        {
            return new VeiculoDTO(
                veiculo.Id,
                veiculo.Marca,
                veiculo.Modelo,
                veiculo.Cor,
                veiculo.Placa,
                veiculo.Tipo,
                veiculo.EstabelecimentoId
                );
        }

        public static Veiculo ConverterParaEntidade(VeiculoDTO veiculoDTO)
        {
            return new Veiculo(
                veiculoDTO.Id,
                veiculoDTO.Marca,
                veiculoDTO.Modelo,
                veiculoDTO.Cor,
                veiculoDTO.Placa,
                veiculoDTO.Tipo,
                veiculoDTO.EstabelecimentoId
                );
        }
    }


}
