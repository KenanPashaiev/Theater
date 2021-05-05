using FluentValidation;
using Theater.BL.Models.Hall;

namespace Theater.Validators
{
    public class HallSectionCreateUpdateDtoValidator : AbstractValidator<HallSectionCreateUpdateDto>
    {
        public HallSectionCreateUpdateDtoValidator()
        {
            RuleFor(n => n.Name).NotEmpty();
            RuleFor(n => n.RowCount).GreaterThanOrEqualTo(1);
            RuleFor(n => n.SeatCount).GreaterThanOrEqualTo(1);
            RuleFor(n => n.Order).GreaterThanOrEqualTo(1);
        }
    }
}
