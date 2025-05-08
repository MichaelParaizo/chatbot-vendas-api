namespace Vendas.Api.Models
{
    public class PedidoItemSabor
    {
        public int Id { get; set; }

        public int PedidoItemId { get; set; }
        public PedidoItem PedidoItem { get; set; } = default!;

        public int SaborId { get; set; }
        public Sabor Sabor { get; set; } = default!;
    }

}
