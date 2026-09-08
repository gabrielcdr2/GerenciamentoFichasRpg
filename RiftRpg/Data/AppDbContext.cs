using Microsoft.EntityFrameworkCore;
using RiftRpg.Models;
using RiftRpg.Models.Enumerates;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Cada DbSet vira uma tabela no banco de dados
    public DbSet<User> Usuarios { get; set; }
    public DbSet<Ficha> Fichas { get; set; }
    public DbSet<InventarioFicha> InventarioFichas { get; set; }
   
    
}