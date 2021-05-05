using FluentValidation;
using Theater.BL.Models.Hall;

namespace Theater.Validators
{
    public class HallUpdateDtoValidator : AbstractValidator<HallUpdateDto>
    {
        public HallUpdateDtoValidator()
        {
            RuleFor(n => n.EffectiveTime).NotNull();
        }
    }
}
