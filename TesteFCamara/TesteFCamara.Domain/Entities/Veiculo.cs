﻿using System;
using System.Collections.Generic;
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
    }
}
