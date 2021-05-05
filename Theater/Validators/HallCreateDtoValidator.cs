using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Theater.BL.Models.Hall;
using Theater.BL.Services;

namespace Theater.Validators
{
    public class HallCreateDtoValidator : AbstractValidator<HallCreateDto>
    {
        private const string OrderMustBeUniqueMessage = "Hall section orders must be unique";
        private const string HallWithSameNameExistsMessage = "Hall with this name already exists";

        private readonly IHallService hallService;

        public HallCreateDtoValidator(IHallService hallService)
        {
            this.hallService = hallService;

            RuleFor(n => n.Name)
                .MustAsync(HallWithSameNameDoesNotExist)
                .WithMessage(HallWithSameNameExistsMessage)
                .NotEmpty();

            RuleFor(n => n.HallSections)
                .Must(SectionOrderIsUnique)
                .WithMessage(OrderMustBeUniqueMessage)
                .NotEmpty();
            RuleForEach(n => n.HallSections)
                .SetValidator(new HallSectionCreateUpdateDtoValidator());

            RuleFor(n => n.EffectiveTime).NotNull();
        }

        public bool SectionOrderIsUnique(ICollection<HallSectionCreateUpdateDto> hallSectionDtos)
        {
            return hallSectionDtos.Select(h => h.Order)
                .Distinct().Count() == hallSectionDtos.Count;
        }

        public async Task<bool> HallWithSameNameDoesNotExist(string hallName, CancellationToken token)
        {
            var existingNote = await hallService.GetHallByNameAsync(hallName);
            return existingNote == null;
        }
    }
}
