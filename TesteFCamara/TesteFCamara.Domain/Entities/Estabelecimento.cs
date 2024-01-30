namespace TesteFCamara.Domain.Entities
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int QtdVagasMoto { get; set; }
        public int QtdVagasCarro { get; set; }
        public List<Veiculo>? Veiculos { get; set; }

        public Estabelecimento()
        {
            
        }

        public Estabelecimento(int id, string nome, string cnpj, string endereco, string telefone, int qtdVagasMoto, int qtdVagasCarro, List<Veiculo>? veiculos)
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

        public Estabelecimento(string nome, string cnpj, string endereco, string telefone, int qtdVagasMoto, int qtdVagasCarro, List<Veiculo>? veiculos)
            : this(default, nome, cnpj, endereco, telefone, qtdVagasMoto, qtdVagasCarro, veiculos) { }

        public Estabelecimento(string nome, string cnpj, string endereco, string telefone, int qtdVagasMoto, int qtdVagasCarro)
            : this(default, nome, cnpj, endereco, telefone, qtdVagasMoto, qtdVagasCarro, default) { }
    }
}
