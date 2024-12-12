using Jose;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace api.Authentication
{
    public class TokenAcess
    {
        public string Token { get; set; }

        public string GenerateToken(string email)
        {
            SecurityEntity securityEntity = new();

            var payload = new Dictionary<string, object>
             {
                { "iss", securityEntity.Issuer },
                { "aud", securityEntity.Audience },
                { "sub", email }, // O e-mail é armazenado na claim "sub"
                { "exp", DateTimeOffset.UtcNow.AddHours(12).ToUnixTimeSeconds() }
            };

            string token = JWT.Encode(payload, Encoding.UTF8.GetBytes(securityEntity.Key), JwsAlgorithm.HS256);

            return token;
        }

        public string GetEmailFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            // Verifica se o token é válido e pode ser lido
            if (handler.CanReadToken(token))
            {
                var jwtToken = handler.ReadJwtToken(token);

                // Busca o e-mail na claim "sub"
                var email = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

                return email ?? throw new ArgumentException("Email não encontrado no token.");
            }
            else
            {
                throw new ArgumentException("Token inválido.");
            }
        }

        public bool IsTokenExpired(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            // Verifica se o token é válido e pode ser lido
            if (handler.CanReadToken(token))
            {
                var jwtToken = handler.ReadJwtToken(token);

                // Obtém a claim "exp" do token
                var expClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;

                if (long.TryParse(expClaim, out var expUnix))
                {
                    // Converte o tempo de expiração de Unix para DateTime
                    var expirationDate = DateTimeOffset.FromUnixTimeSeconds(expUnix).UtcDateTime;

                    // Compara o tempo de expiração com o tempo atual
                    return expirationDate < DateTime.UtcNow;
                }

                throw new ArgumentException("O token não possui um tempo de expiração válido.");
            }
            else
            {
                throw new ArgumentException("Token inválido.");
            }
        }
    }
}
