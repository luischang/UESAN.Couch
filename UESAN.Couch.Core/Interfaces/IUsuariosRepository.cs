using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<bool> IsEmailRegistered(string correoElectronico);
        Task<Usuarios> SignIn(string email, string password);
        Task<bool> SignUp(Usuarios user);
        Task<int> Insert(Usuarios usuarios);

    }
}