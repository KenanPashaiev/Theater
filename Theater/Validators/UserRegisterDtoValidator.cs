using FluentValidation;
using Theater.BL.Models.User;

namespace Theater.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        private const int MinPasswordLength = 6;
        private const int MaxPasswordLength = 24;

        private const int MinPhoneNumberLength = 8;
        private const int MaxPhoneNumberLength = 18;

        public UserRegisterDtoValidator()
        {
            RuleFor(n => n.Email)
                .EmailAddress();

            RuleFor(n => n.Password)
                .Length(MinPasswordLength, MaxPasswordLength);

            RuleFor(n => n.FirstName)
                .NotEmpty();

            RuleFor(n => n.LastName)
                .NotEmpty();

            RuleFor(n => n.PhoneNumber)
                .Length(MinPhoneNumberLength, MaxPhoneNumberLength);
        }
    }
}
