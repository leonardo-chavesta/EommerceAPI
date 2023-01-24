using Application.Base;
using Application.Dtos.Usuarios;

namespace Application.Services.Abstractions
{
    public interface IUsuarioService
    {
        Task<IList<UsuarioDto>> ListaUsuarios();
        Task<BaseResponse<object>> GenerarToken(TokenRequestDto requestDto);
        Task<BaseResponse<bool>> Register(UsuarioFormDto requestDto);
    }
}
