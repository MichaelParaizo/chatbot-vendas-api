namespace Vendas.Api.Models
{
    public class Pedido
    {

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string Observacao { get; set; }
        public PedidoStatus Status { get; set; } // Enum: Andamento, Preparando, Finalizado

        public decimal Total { get; set; }

        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; }

        public ICollection<PedidoItem> Itens { get; set; }
    }
}
