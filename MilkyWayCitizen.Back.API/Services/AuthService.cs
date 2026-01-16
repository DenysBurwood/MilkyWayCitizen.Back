using Microsoft.IdentityModel.Tokens;
using MilkyWayCitizen.Back.DL.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MilkyWayCitizen.Back.API.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config=config;
        }

        public string GenerateToken(User user)
        {

            List<Claim> claims = new List<Claim>(){
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    //new Claim(ClaimTypes.Role, employee is null ? "Client" : employee.EmployeeType.ToString()),
                    new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString()),
                    //new Claim(ClaimTypes.Name, user.FirstName),
                    //new Claim(ClaimTypes.Upn, user.LastName),
                };

            string secretKey = _config["Jwt:Key"];
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
