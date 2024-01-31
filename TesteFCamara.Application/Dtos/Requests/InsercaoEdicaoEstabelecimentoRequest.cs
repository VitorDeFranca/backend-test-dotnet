using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFCamara.Domain.Entities;

namespace TesteFCamara.Application.Dtos.Requests
{
    public class InsercaoEdicaoEstabelecimentoRequest
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int QtdVagasDispMoto { get; set; }
        public int QtdVagasDispCarro { get; set; }

        public InsercaoEdicaoEstabelecimentoRequest(string nome, string cnpj, string endereco, string telefone, int qtdVagasDispMoto, int qtdVagasDispCarro)
        {
            Nome = nome;
            CNPJ = cnpj;
            Endereco = endereco;
            Telefone = telefone;
            QtdVagasDispMoto = qtdVagasDispMoto;
            QtdVagasDispCarro = qtdVagasDispCarro;
        }

        public static Estabelecimento ConverterParaEntidade(InsercaoEdicaoEstabelecimentoRequest model)
        {
            return new Estabelecimento(
                model.Nome,
                model.CNPJ,
                model.Endereco,
                model.Telefone,
                model.QtdVagasDispMoto,
                model.QtdVagasDispCarro
                );
        }

    }
}
