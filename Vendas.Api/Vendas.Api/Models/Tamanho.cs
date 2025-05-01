namespace Vendas.Api.Models
{
    public class Tamanho
    {
        public int Id { get; set; }
        public string Descricao { get; set; } // Pequena, Média, Grande
        public decimal ValorBase { get; set; }
    }
}
