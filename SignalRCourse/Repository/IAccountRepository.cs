using SignalRCourse.Model;

namespace SignalRCourse.Repository
{
    public interface IAccountRepository
    {
        Task<bool> RegisterAccount(RegisterAccountDto register);

        Task<bool> LoginAccount(LoginAccountDto login);

        Task<bool> SignOutAsync();
    }
}
