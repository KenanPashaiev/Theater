using FluentValidation;
using Theater.BL.Models.User;

namespace Theater.Validators
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        private const int MinPhoneNumberLength = 8;
        private const int MaxPhoneNumberLength = 18;

        public UserUpdateDtoValidator()
        {
            RuleFor(n => n.FirstName)
                .NotEmpty();

            RuleFor(n => n.LastName)
                .NotEmpty();

            RuleFor(n => n.PhoneNumber)
                .Length(MinPhoneNumberLength, MaxPhoneNumberLength);
        }
    }
}
