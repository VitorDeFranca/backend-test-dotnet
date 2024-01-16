namespace TesteFCamara.Domain.Entities
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int QtdMotos { get; set; }
        public int QtdCarros { get; set; }
        public List<Veiculo>? Veiculos { get; set; }
    }
}
