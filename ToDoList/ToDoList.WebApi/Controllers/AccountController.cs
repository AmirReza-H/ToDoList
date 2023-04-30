using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.Account;
using ToDoList.Application.Interfaces.Identity;

namespace ToDoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly IValidator<RegisterRequest> _validator;

        public AccountController(IAccountService accountService, IValidator<RegisterRequest> validator)
        {
            _accountService = accountService;
            _validator = validator;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<string> RegisterAsync(RegisterRequest request)
        {
            return await _accountService.RegisterAsync(request);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
           => await _accountService.AuthenticateAsync(request);


    }
}
