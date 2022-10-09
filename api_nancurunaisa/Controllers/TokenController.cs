using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_nancurunaisa.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly nancurunaisadbContext _context;
        public static AuthToken authToken = new AuthToken();

        public TokenController(IConfiguration config, nancurunaisadbContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MasajistaCredentials _userData)
        {
            if (_userData != null && _userData.email != null && _userData.password != null)
            {
                var user = await GetUser(_userData.email, _userData.password);

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
                    return Ok(authToken);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<masajista> GetUser(string email, string password)
        {
            return await _context.masajista.FirstOrDefaultAsync(u => u.correo == email && u.password == password);
        }
    }
}
