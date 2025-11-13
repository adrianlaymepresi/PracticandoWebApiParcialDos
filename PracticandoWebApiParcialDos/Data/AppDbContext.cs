using Microsoft.EntityFrameworkCore;
using PracticandoWebApiParcialDos.Models;

namespace PracticandoWebApiParcialDos.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<DetallePedido> DetallePedidos => Set<DetallePedido>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
