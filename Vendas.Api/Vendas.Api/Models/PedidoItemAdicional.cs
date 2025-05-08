namespace Vendas.Api.Models
{
    public class PedidoItemAdicional
    {
        public int Id { get; set; }

        public int PedidoItemId { get; set; }
        public PedidoItem PedidoItem { get; set; } = default!;

        public int AdicionalId { get; set; }
        public Adicional Adicional { get; set; } = default!;
    }
}
