using System.ComponentModel.DataAnnotations.Schema;

namespace Vendas.Api.Models
{
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = default!;

        public string Observacao { get; set; } = default!;
        public PedidoStatus Status { get; set; } // Enum: Andamento, Preparando, Finalizado

        public decimal Total { get; set; }

        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; } = default!;

        public ICollection<PedidoItem> Itens { get; set; }
    }
}
