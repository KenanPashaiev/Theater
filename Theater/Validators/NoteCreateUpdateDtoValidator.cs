using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Theater.BL.Models.Note;
using Theater.BL.Services;

namespace Theater.Validators
{
    public class NoteCreateUpdateDtoValidator : AbstractValidator<NoteCreateUpdateDto>
    {
        private const string NoteWithSameNameExistsMessage = "Note with this name already exists";

        private readonly INoteService noteService;

        public NoteCreateUpdateDtoValidator(INoteService noteService)
        {
            this.noteService = noteService;

            RuleFor(n => n.Name)
                .MustAsync(NoteWithSameNameDoesNotExist)
                .WithMessage(NoteWithSameNameExistsMessage)
                .NotEmpty();

            RuleFor(n => n.Text).NotEmpty();
        }

        public async Task<bool> NoteWithSameNameDoesNotExist(string noteName, CancellationToken token)
        {
            var existingNote = await noteService.GetNoteByNameAsync(noteName);
            return existingNote == null;
        }
    }
}
