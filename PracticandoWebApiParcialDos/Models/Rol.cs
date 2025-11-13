using System.ComponentModel.DataAnnotations;

namespace PracticandoWebApiParcialDos.Models
{
    public class Rol
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string NombreRol { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Descripcion { get; set; } = string.Empty;

        public bool EstaActivo { get; set; } = false;

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
