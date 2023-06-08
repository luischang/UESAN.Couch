using UESAN.Couch.Core.Settings;
using UESAN.Couch.Infrastructure.Data;



namespace UESAN.Couch.Core.Interfaces
{
    public interface IJWTFactory
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(Usuarios user);
    }
}