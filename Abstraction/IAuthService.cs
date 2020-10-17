using ResponseModel;

namespace Abstraction
{
    public interface IAuthService
    {
        TokenResponse GetToken();
    }
}