using FluentValidation;

namespace ToDoList.Application.DTOs.Account
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ConfirmPassword { get; set; }
        public int? Role { get; set; }
    }
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().NotNull()
                .MinimumLength(3)
                .WithName("نام");

            RuleFor(x => x.LastName)
                .NotEmpty().NotNull()
                .MinimumLength(3)
                .WithName("نام خانوادگی");

            RuleFor(x => x.UserName)
                .NotEmpty().NotNull()
                .MinimumLength(5)
                .WithName("شناسه کاربری");

            RuleFor(x => x.Email)
                .NotEmpty().NotNull()
                .EmailAddress()
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                .WithName("ایمیل");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().NotNull()
                .Length(11).Matches("^09\\d{9}$")
                .WithName("تلفن همراه");

            RuleFor(x => x.Role)
                .NotEmpty().NotNull()
                .WithName("نقش");

            RuleFor(x => x.Password)
                .NotEmpty().NotNull()
                .MinimumLength(6)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$")
                .WithName("رمز عبور");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithName("تایید رمز عبور");
        }
    }
}
