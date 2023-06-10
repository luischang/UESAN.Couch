using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Core.Settings;
using UESAN.Couch.Infrastructure.Data;


namespace UESAN.Couch.Infrastructure.Shared
{
    public class JWTFactory : IJWTFactory
    {
        public JWTSettings _settings { get; }
        public JWTFactory(IOptions<JWTSettings> settings)
        {
            _settings = settings.Value;
        }


        //aqui mejoramos el metodo de generar el token
        public string GenerateJWToken(Usuarios user)
        {
            
                var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
                var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
                var header = new JwtHeader(sc);
        
                var claims = new[] {
                new Claim(ClaimTypes.Name, (user.Nombre + "" + user.Apellido)),
                new Claim(ClaimTypes.GivenName, user.Nombre),
                new Claim(ClaimTypes.Email, user.CorreoElectronico),
                new Claim(ClaimTypes.Role, user.IdTipoNavegation.Equals(1) ? "Coach" : "Emprendedor"),
                new Claim("IdPersona",user.IdPersona.ToString()),
                };

            



            var payload = new JwtPayload(
                            _settings.Issuer
                            , _settings.Audience
                            , claims
                            , DateTime.UtcNow
                            , DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes));

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
