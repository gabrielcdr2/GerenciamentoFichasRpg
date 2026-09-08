using Microsoft.EntityFrameworkCore;
using RiftRpg.Models;

namespace RiftRpg.Services
{
    public class FichaService
    {
        private readonly AppDbContext _context; // ajuste pro nome real do seu DbContext

        public FichaService(AppDbContext context)
        {
            _context = context;
        }

        // Listar todas as fichas de um usuário (usado na Home)
        public async Task<List<Ficha>> GetFichasByUsuarioAsync(int idUsuario)
        {
            return await _context.Fichas
                .Where(f => f.IdUsuario == idUsuario)
                .OrderByDescending(f => f.Id)
                .ToListAsync();
        }

        // Buscar uma ficha específica, garantindo que pertence ao usuário
        public async Task<Ficha?> GetFichaByIdAsync(int idFicha, int idUsuario)
        {
            return await _context.Fichas
                .FirstOrDefaultAsync(f => f.Id == idFicha && f.IdUsuario == idUsuario);
        }

        // Criar nova ficha
        public async Task<Ficha> CreateFichaAsync(Ficha ficha)
        {
            _context.Fichas.Add(ficha);
            await _context.SaveChangesAsync();
            return ficha;
        }

        // Atualizar ficha existente
        public async Task<(bool success, string message)> UpdateFichaAsync(Ficha fichaAtualizada, int idUsuario)
        {
            var ficha = await GetFichaByIdAsync(fichaAtualizada.Id, idUsuario);

            if (ficha is null)
                return (false, "Ficha não encontrada.");

            // Atualiza os campos (ou usa AutoMapper/reflexão se preferir)
            _context.Entry(ficha).CurrentValues.SetValues(fichaAtualizada);

            await _context.SaveChangesAsync();
            return (true, "Ficha atualizada com sucesso.");
        }

        // Excluir ficha
        public async Task<(bool success, string message)> DeleteFichaAsync(int idFicha, int idUsuario)
        {
            var ficha = await GetFichaByIdAsync(idFicha, idUsuario);

            if (ficha is null)
                return (false, "Ficha não encontrada.");

            _context.Fichas.Remove(ficha);
            await _context.SaveChangesAsync();
            return (true, "Ficha excluída com sucesso.");
        }

        // Contar quantas fichas o usuário tem (útil pra limites, se você quiser restringir)
        public async Task<int> CountFichasByUsuarioAsync(int idUsuario)
        {
            return await _context.Fichas.CountAsync(f => f.IdUsuario == idUsuario);
        }
    }
}
