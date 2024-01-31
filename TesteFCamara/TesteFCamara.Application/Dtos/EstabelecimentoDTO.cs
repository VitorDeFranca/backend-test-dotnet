using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFCamara.Domain.Entities;

namespace TesteFCamara.Application.Dtos
{
    public class EstabelecimentoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int QtdVagasMoto { get; set; }
        public int QtdVagasCarro { get; set; }
        public List<VeiculoDTO>? Veiculos { get; set; }

        public EstabelecimentoDTO(int id, string nome, string cnpj, string endereco, string telefone, int qtdVagasMoto, int qtdVagasCarro, List<VeiculoDTO>? veiculos) 
        {
            Id = id;
            Nome = nome;
            CNPJ = cnpj;
            Endereco = endereco;
            Telefone = telefone;
            QtdVagasMoto = qtdVagasMoto;
            QtdVagasCarro = qtdVagasCarro;
            Veiculos = veiculos;
        }

        public EstabelecimentoDTO(int id, string nome, string cnpj, string endereco, string telefone, int qtdVagasMoto, int qtdVagasCarro)
        {
            Id = id;
            Nome = nome;
            CNPJ = cnpj;
            Endereco = endereco;
            Telefone = telefone;
            QtdVagasMoto = qtdVagasMoto;
            QtdVagasCarro = qtdVagasCarro;
        }

        public static EstabelecimentoDTO ConverterParaResponse(Estabelecimento estabelecimento)
        {
            if (estabelecimento.Veiculos != null)
            {
                var listaVeiculos = new List<VeiculoDTO>();
                foreach (Veiculo veiculo in estabelecimento.Veiculos) {
                    listaVeiculos.Add(VeiculoDTO.ConverterParaResponse(veiculo));
                }

                return new EstabelecimentoDTO(
                estabelecimento.Id,
                estabelecimento.Nome,
                estabelecimento.CNPJ,
                estabelecimento.Endereco,
                estabelecimento.Telefone,
                estabelecimento.QtdVagasDispMoto,
                estabelecimento.QtdVagasDispCarro,
                listaVeiculos
                );

            }

            return new EstabelecimentoDTO(
                estabelecimento.Id,
                estabelecimento.Nome,
                estabelecimento.CNPJ,
                estabelecimento.Endereco,
                estabelecimento.Telefone,
                estabelecimento.QtdVagasDispMoto,
                estabelecimento.QtdVagasDispCarro
                );
        }

        public static Estabelecimento ConverterParaEntidade(EstabelecimentoDTO estabelecimentoDTO)
        {
            if (estabelecimentoDTO.Veiculos != null)
            {
                var listaVeiculos = new List<Veiculo>();
                foreach (VeiculoDTO veiculo in estabelecimentoDTO.Veiculos)
                {
                    listaVeiculos.Add(VeiculoDTO.ConverterParaEntidade(veiculo));
                }

                return new Estabelecimento(
                estabelecimentoDTO.Nome,
                estabelecimentoDTO.CNPJ,
                estabelecimentoDTO.Endereco,
                estabelecimentoDTO.Telefone,
                estabelecimentoDTO.QtdVagasMoto,
                estabelecimentoDTO.QtdVagasCarro,
                listaVeiculos
                );

            }

            return new Estabelecimento(
                estabelecimentoDTO.Nome,
                estabelecimentoDTO.CNPJ,
                estabelecimentoDTO.Endereco,
                estabelecimentoDTO.Telefone,
                estabelecimentoDTO.QtdVagasMoto,
                estabelecimentoDTO.QtdVagasCarro
                );
        }


    }
}
