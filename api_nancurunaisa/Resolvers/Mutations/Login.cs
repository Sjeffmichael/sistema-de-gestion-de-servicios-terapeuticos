using api_nancurunaisa.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class Login
    {
        public static AuthToken authToken = new AuthToken();

        [GraphQLDescription("Autenticación de usuarios")]
        public async Task<Token> Authentication(
            [Service] IConfiguration _configuration,
            [Service] nancurunaisadbContext _context,
            string? email,
            string? password
        )
        {
            if (email != null && password != null)
            {
                var user = await GetUser(
                    _context, 
                    email,
                    Encrypt.GetSHA256(password)
                );

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.idMasajista.ToString()),
                        new Claim("Email", user.correo),
                        new Claim("Roll", user.roll),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);
                    authToken.token = new JwtSecurityTokenHandler().WriteToken(token);

                    var generatedToken = new Token()
                    {
                        token = authToken
                    };

                    return generatedToken;
                    //return Ok(authToken);
                }
                else
                {
                    //return BadRequest("Invalid credentials");
                    throw new GraphQLException(new Error("Credenciales invalidas"));
                }
            }
            else
            {
                //return BadRequest();
                throw new GraphQLException(new Error("Contraseña o email requeridas"));
            }
        }

        private async Task<masajista?> GetUser(
            [Service] nancurunaisadbContext _context, 
            string email, 
            string password
        )
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false; 
            return await _context.masajista.FirstOrDefaultAsync(
                u => u.activo == true && u.correo == email && u.password == password
            );
        }
    }
}
