using System.ComponentModel.DataAnnotations;

namespace PracticandoWebApiParcialDos.Models.DTOs
{
    public class RolRegistrarDto
    {
        [Required, MaxLength(30)]
        public string NombreRol { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Descripcion { get; set; } = string.Empty;

        public bool EstaActivo { get; set; } = true;
    }

    public class RolActualizarDto
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string NombreRol { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Descripcion { get; set; } = string.Empty;

        public bool EstaActivo { get; set; } = true;
    }

    public class RolIdDto
    {
        [Required]
        public int Id { get; set; }
    }
}
