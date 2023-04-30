using FluentValidation;

namespace ToDoList.Application.DTOs.Account
{
    public class AuthenticationRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().NotNull()
                .WithName("نام کاربری");

            RuleFor(x => x.Password)
                .NotEmpty().NotNull()
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$")
                .WithName("رمز عبور");
        }
    }
}
