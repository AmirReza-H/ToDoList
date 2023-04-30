using ToDoList.Application.DTOs.Account;

namespace ToDoList.Application.Interfaces.Identity
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<string> RegisterAsync(RegisterRequest request);
    }
}
