using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public interface IUsuariosRepository
    {
        Task<bool> IsEmailRegistered(string correoElectronico);
        Task<Usuarios> SignIn(string email, string password);
        Task<bool> SignUpCoach(Usuarios user);
        Task<bool> SignUpEmprendedor(Usuarios user);
    }
}