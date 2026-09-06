using Microsoft.EntityFrameworkCore;
using RiftRpg.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Cada DbSet vira uma tabela no banco de dados
    public DbSet<User> Usuarios { get; set; }
}