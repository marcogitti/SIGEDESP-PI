using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace api.Authentication
{
    public class Login
    {
        [Required(ErrorMessage = "O e-mail é requerido!")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é requerida!")]
        [MinLength(6)]
        public string Senha
        {
            get => senha;
            set
            {
                senha = GenerateHash(value);
            }
        }

        // Propriedade que armazena a senha em texto claro
        private string? senha;

        public string GenerateHash(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = SHA256.HashData(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
