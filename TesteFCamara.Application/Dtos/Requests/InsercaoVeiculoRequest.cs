using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TesteFCamara.Domain.Entities;

namespace TesteFCamara.Application.Dtos.Requests
{
    public class InsercaoVeiculoRequest
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Tipo { get; set; }

        public InsercaoVeiculoRequest(string marca, string modelo, string cor, string placa, string tipo)
        {
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
            Placa = placa;
            Tipo = tipo;
        }

        public static Veiculo ConverterParaEntidade(int estabelecimentoId, InsercaoVeiculoRequest model)
        {
            return new Veiculo(
                model.Marca,
                model.Modelo,
                model.Cor,
                model.Placa,
                model.Tipo,
                estabelecimentoId
                );
        }
    }
}
