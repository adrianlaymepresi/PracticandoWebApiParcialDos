using System.ComponentModel.DataAnnotations;

namespace PracticandoWebApiParcialDos.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public int CarnetIdentidad { get; set; }

        [Required, MaxLength(50)]
        public string Nombres { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Apellidos { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Telefono { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Direccion { get; set; } = string.Empty;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
