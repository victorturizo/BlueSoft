using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BookStoreBluesoft.WebApi.JWTImplementation
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
    public class UserService : IUserService
    {

        private List<UserEntity> _users = new List<UserEntity>
        {
            new UserEntity { Id = 1,
                            Nombres = "Victor", 
                            Apellidos = "Turizo", 
                            Username = "VHTurizo",
                            Password = "12345" }
                            };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            var useresult = new User { Username = user.Username, Nombres = user.Nombres, Apellidos = user.Apellidos };

            if (useresult == null)
                return null;

            // authentication exitosa para generar jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            useresult.Token = tokenHandler.WriteToken(token);
            useresult.Expires = TimeSpan.FromMinutes(10).TotalSeconds;
            return useresult;
        }
    }
}
