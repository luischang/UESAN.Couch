using UESAN.Couch.Infrastructure.Data;
using UESAN.Shopping.Core.Settings;


namespace UESAN.Shopping.Core.Interfaces
{
    public interface IJWTFactory
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(Usuarios user);
    }
}