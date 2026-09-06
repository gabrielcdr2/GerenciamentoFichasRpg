using System.ComponentModel.DataAnnotations;

namespace RiftRpg.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Password { get; set; } = string.Empty;
    }
}