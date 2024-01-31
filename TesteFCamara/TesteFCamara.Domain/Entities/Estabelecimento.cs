namespace TesteFCamara.Domain.Entities
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int QtdVagasDispMoto { get; set; }
        public int QtdVagasDispCarro { get; set; }
        public List<Veiculo>? Veiculos { get; set; }

        public Estabelecimento()
        {
            
        }

        public Estabelecimento(int id, string nome, string cnpj, string endereco, string telefone, int qtdVagasDispMoto, int qtdVagasDispCarro, List<Veiculo>? veiculos)
        {
            Id = id;
            Nome = nome;
            CNPJ = cnpj;
            Endereco = endereco;
            Telefone = telefone;
            QtdVagasDispMoto = qtdVagasDispMoto;
            QtdVagasDispCarro = qtdVagasDispCarro;
            Veiculos = veiculos;
        }

        public Estabelecimento(string nome, string cnpj, string endereco, string telefone, int qtdVagasDispMoto, int qtdVagasDispCarro, List<Veiculo>? veiculos)
            : this(default, nome, cnpj, endereco, telefone, qtdVagasDispMoto, qtdVagasDispCarro, veiculos) { }

        public Estabelecimento(string nome, string cnpj, string endereco, string telefone, int qtdVagasDispMoto, int qtdVagasDispCarro)
            : this(default, nome, cnpj, endereco, telefone, qtdVagasDispMoto, qtdVagasDispCarro, default) { }
    }
}
