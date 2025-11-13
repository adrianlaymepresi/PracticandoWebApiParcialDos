using Microsoft.EntityFrameworkCore;
using PracticandoWebApiParcialDos.Data;
using PracticandoWebApiParcialDos.Models;
using PracticandoWebApiParcialDos.Models.DTOs;

namespace PracticandoWebApiParcialDos.Services
{
    public class RolService
    {
        private readonly AppDbContext _context;

        public RolService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> ObtenerTodosAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Rol> ObtenerPorIdAsync(RolIdDto dto)
        {
            var rol = await _context.Roles.FindAsync(dto.Id);
            if (rol == null)
                throw new Exception("Rol no encontrado");

            return rol;
        }

        public async Task<Rol> RegistrarAsync(RolRegistrarDto dto)
        {
            if (await _context.Roles.AnyAsync(r => r.NombreRol == dto.NombreRol))
                throw new Exception("El nombre del rol ya existe");

            var rol = new Rol
            {
                NombreRol = dto.NombreRol,
                Descripcion = dto.Descripcion,
                EstaActivo = dto.EstaActivo
            };

            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task<Rol> ActualizarAsync(RolActualizarDto dto)
        {
            var rol = await _context.Roles.FindAsync(dto.Id);
            if (rol == null)
                throw new Exception("Rol no encontrado");

            rol.NombreRol = dto.NombreRol;
            rol.Descripcion = dto.Descripcion;
            rol.EstaActivo = dto.EstaActivo;

            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task<Rol> BorradoLogicoAsync(RolIdDto dto)
        {
            var rol = await _context.Roles.FindAsync(dto.Id);
            if (rol == null)
                throw new Exception("Rol no encontrado");

            rol.EstaActivo = false;
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task<Rol> BorradoFisicoAsync(RolIdDto dto)
        {
            var rol = await _context.Roles.FindAsync(dto.Id);
            if (rol == null)
                throw new Exception("Rol no encontrado");

            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
            return rol;
        }
    }
}
