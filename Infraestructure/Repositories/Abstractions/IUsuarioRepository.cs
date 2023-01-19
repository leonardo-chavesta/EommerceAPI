using Domain;

namespace Infraestructure.Repositories.Abstractions
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> Autentifica(Usuario admin);
        Task<bool>Register(Usuario admin);
        Task<Usuario> AcountCorreo(string correo);
        Task<Usuario> UserByCorreo(string email);
    }
}
