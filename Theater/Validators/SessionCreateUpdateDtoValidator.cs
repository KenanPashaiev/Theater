using FluentValidation;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Theater.BL.Models.Session;
using Theater.BL.Services;

namespace Theater.Validators
{
    public class SessionCreateUpdateDtoValidator : AbstractValidator<SessionCreateUpdateDto>
    {
        private const string SessionOverlapsMessage = "Session overlaps with other sessions in this Hall";
        private const string HallDoesNotExistMessage = "Specified hall does not exist";

        private const string StartTimeMessage = "Session 'Start Time' should be earlier then 'End Time'";
        private const string BookingOpenDateMessage = "Session 'Booking Open Date' should be earlier then 'Booking Close Date'";

        private readonly ISessionService sessionService;
        private readonly IHallService hallService;

        public SessionCreateUpdateDtoValidator(ISessionService sessionService,
            IHallService hallService)
        {
            this.sessionService = sessionService;
            this.hallService = hallService;

            RuleFor(n => n)
                .MustAsync(SessionDoesNotOverlapWithOther)
                .WithMessage(SessionOverlapsMessage);

            RuleFor(n => n.Name).NotEmpty();

            RuleFor(n => n.StartTime).NotEmpty();
            RuleFor(n => n.EndTime).NotEmpty();

            RuleFor(n => n.BookingOpenDate).NotEmpty();
            RuleFor(n => n.BookingCloseDate).NotEmpty();

            RuleFor(n => n.StartTime)
                .LessThan(n => n.EndTime)
                .WithMessage(StartTimeMessage);

            RuleFor(n => n.BookingOpenDate)
                .LessThan(n => n.BookingCloseDate)
                .WithMessage(BookingOpenDateMessage);

            RuleFor(n => n.SessionType).IsInEnum();

            RuleFor(n => n.HallId)
                .MustAsync(HallExists)
                .WithMessage(HallDoesNotExistMessage);
        }

        public async Task<bool> SessionDoesNotOverlapWithOther(SessionCreateUpdateDto sessionDto, CancellationToken token)
        {
            var existingSessions = await sessionService.GetSessionByHallAsync(sessionDto.HallId, true);
            var overlapingSessions = existingSessions.Where(s => sessionDto.StartTime < s.EndTime &&
                                        s.StartTime < sessionDto.EndTime);
            return !overlapingSessions.Any();
        }

        public async Task<bool> HallExists(Guid hallId, CancellationToken token)
        {
            var hall = await hallService.GetHallAsync(hallId);
            return hall != null;
        }
    }
}
