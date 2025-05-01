namespace Vendas.Api.Models
{
    public class PedidoItem
    {
        public int Id { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int TamanhoId { get; set; }
        public Tamanho Tamanho { get; set; }

        public string Observacao { get; set; }

        public ICollection<PedidoItemSabor> Sabores { get; set; }
        public ICollection<PedidoItemAdicional> Adicionais { get; set; }
    }
}
