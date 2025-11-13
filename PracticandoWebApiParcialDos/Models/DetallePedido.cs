using System.ComponentModel.DataAnnotations;

namespace PracticandoWebApiParcialDos.Models
{
    public class DetallePedido
    {
        public int Id { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        public bool EstaActivo { get; set; } = true;

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public int ProductoId { get; set; }
    }
}
