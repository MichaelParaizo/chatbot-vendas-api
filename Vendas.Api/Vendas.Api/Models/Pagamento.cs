namespace Vendas.Api.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public FormaPagamento Forma { get; set; } // Enum: Débito, Crédito, Dinheiro, Pix
        public DateTime DataPagamento { get; set; }
        public bool Pago { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
