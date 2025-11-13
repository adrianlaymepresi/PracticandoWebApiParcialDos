using System.ComponentModel.DataAnnotations;

namespace PracticandoWebApiParcialDos.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;       

        public bool EstaActivo { get; set; } = true;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required]
        public int RolId { get; set; }

        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
