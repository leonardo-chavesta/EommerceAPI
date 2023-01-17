using Domain;

namespace Infraestructure.Repositories.Abstractions
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> Autentifica(Usuario admin);
    }
}
