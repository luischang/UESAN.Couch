using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public interface ITiposUsuariosRepository
    {
        Task<bool> IsEmailRegistered(string correoElectronico);
        Task<Usuarios> SignIn(string email, string password);
        Task<bool> SignUp(Usuarios user);
    }
}