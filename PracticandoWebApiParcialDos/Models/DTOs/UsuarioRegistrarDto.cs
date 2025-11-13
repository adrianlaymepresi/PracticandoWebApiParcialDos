using System.ComponentModel.DataAnnotations;

namespace PracticandoWebApiParcialDos.Models.DTOs
{
    public class UsuarioRegistrarDto
    {
        [Required, MaxLength(50)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public int RolId { get; set; }
    }

    public class UsuarioActualizarDto
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int RolId { get; set; }
    }

    public class UsuarioActualizarPasswordDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string NuevoPassword { get; set; } = string.Empty;
    }

    public class UsuarioIdDto
    {
        [Required]
        public int Id { get; set; }
    }
}
