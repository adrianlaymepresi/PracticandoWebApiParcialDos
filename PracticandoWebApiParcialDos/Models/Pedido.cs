using System.ComponentModel.DataAnnotations;

namespace PracticandoWebApiParcialDos.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime FechaPedido { get; set; } = DateTime.Now;

        [Required, MaxLength(20)]
        public string Estado { get; set; } = "Pendiente";

        public decimal Total { get; set; }

        [MaxLength(200)]
        public string Observaciones { get; set; } = string.Empty;

        public bool EstaActivo { get; set; } = true;

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public List<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
    }
}
