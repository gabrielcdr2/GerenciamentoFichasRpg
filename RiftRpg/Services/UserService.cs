using System.Security.Cryptography;
using System.Text;
using RiftRpg.Models;
using Microsoft.EntityFrameworkCore;

namespace RiftRpg.Services
{
    public class UserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(bool Success, string Message, User? User)> RegisterUserAsync(string name, string email, string password)
        {
            try
            {
                // Validar entrada
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    return (false, "Nome, e-mail e senha são obrigatórios.", null);
                }

                // Verificar se o email já existe
                var existingUser = await _dbContext.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (existingUser != null)
                {
                    return (false, "Este e-mail já está registrado.", null);
                }

                // Hash da senha
                var passwordHash = HashPassword(password);

                // Criar novo usuário
                var newUser = new User
                {
                    Name = name,
                    Email = email,
                    Login = email, // Usar email como login também
                    PasswordHash = passwordHash,
                    CreatedAt = DateTime.UtcNow
                };

                _dbContext.Usuarios.Add(newUser);
                await _dbContext.SaveChangesAsync();

                return (true, "Usuário criado com sucesso!", newUser);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao criar conta: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, User? User)> LoginAsync(string email, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    return (false, "E-mail e senha são obrigatórios.", null);
                }

                var user = await _dbContext.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {
                    return (false, "E-mail ou senha incorretos.", null);
                }

                // Verificar senha
                if (!VerifyPassword(password, user.PasswordHash))
                {
                    return (false, "E-mail ou senha incorretos.", null);
                }

                return (true, "Login realizado com sucesso!", user);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao fazer login: {ex.Message}", null);
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hash)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == hash;
        }
    }
}
