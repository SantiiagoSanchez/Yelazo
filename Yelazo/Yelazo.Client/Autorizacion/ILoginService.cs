using Yelazo.Shared.DTO;

namespace Yelazo.Client.Autorizacion
{
    public interface ILoginService
    {
        Task Login(UserTokenDTO TokenDTO);
        Task Logout();
    }
}
