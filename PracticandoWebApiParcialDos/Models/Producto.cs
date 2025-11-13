using System.ComponentModel.DataAnnotations;

namespace PracticandoWebApiParcialDos.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }

        public bool EstaActivo { get; set; } = true;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public List<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
    }
}
