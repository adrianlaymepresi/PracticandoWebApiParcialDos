using Microsoft.EntityFrameworkCore;
using PracticandoWebApiParcialDos.Data;
using PracticandoWebApiParcialDos.Models;
using PracticandoWebApiParcialDos.Models.DTOs;
using PracticandoWebApiParcialDos.Utils;
using System.Security.Cryptography;
using System.Text;

namespace PracticandoWebApiParcialDos.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObtenerPorIdAsync(UsuarioIdDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(dto.Id);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            return usuario;
        }

        public async Task<Usuario> RegistrarAsync(UsuarioRegistrarDto dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("Email ya registrado");

            var usuario = new Usuario
            {
                NombreUsuario = dto.NombreUsuario,
                Email = dto.Email,
                RolId = dto.RolId,
                Password = HashPassword(dto.Password)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> ActualizarAsync(UsuarioActualizarDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(dto.Id);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            usuario.NombreUsuario = dto.NombreUsuario;
            usuario.Email = dto.Email;
            usuario.RolId = dto.RolId;

            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> BorradoLogicoAsync(UsuarioIdDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(dto.Id);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            usuario.EstaActivo = false;
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> BorradoFisicoAsync(UsuarioIdDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(dto.Id);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        // EXTRAS
        private string HashPassword(string password)
        {
            var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
