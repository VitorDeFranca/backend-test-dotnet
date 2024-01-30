using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFCamara.Domain.Entities
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Tipo { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public int EstabelecimentoId { get; set; }

        public Veiculo()
        {
            
        }

        public Veiculo(int id, string marca, string modelo, string cor, string placa, string tipo, int estabelecimentoId)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
            Placa = placa;
            Tipo = tipo;
            EstabelecimentoId = estabelecimentoId;
        }

        public Veiculo(string marca, string modelo, string cor, string placa, string tipo, int estabelecimentoId)
            : this(default, marca, modelo, cor, placa, tipo, estabelecimentoId) { }
    }
}
