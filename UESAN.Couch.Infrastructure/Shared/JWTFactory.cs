using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
                new Claim(ClaimTypes.NameIdentifier, user.IdPersona.ToString()),
                new Claim(ClaimTypes.Email, user.CorreoElectronico),
                new Claim(ClaimTypes.Role, user.IdTipo.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Nombre} {user.Apellido}"),
                new Claim("IdPersona", user.IdPersona.ToString()),//esta linea es para que el token tenga el id del usuario
                new Claim("Nombre", user.Nombre),
                new Claim("Apellido", user.Apellido),
                new Claim("Genero", user.Genero),
                new Claim("NroContacto", user.NroContacto),
                new Claim("CorreoElectronico", user.CorreoElectronico),
                new Claim("Contrasena", user.Contrasena)
            
                    
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
