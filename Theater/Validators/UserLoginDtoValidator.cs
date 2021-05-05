using FluentValidation;
using Theater.BL.Models.User;

namespace Theater.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        private const int MinPasswordLength = 6;
        private const int MaxPasswordLength = 24;

        public UserLoginDtoValidator()
        {
            RuleFor(n => n.Email)
                .EmailAddress();

            RuleFor(n => n.Password)
                .Length(MinPasswordLength, MaxPasswordLength);
        }
    }
}
