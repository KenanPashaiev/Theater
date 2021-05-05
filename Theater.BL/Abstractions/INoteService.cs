using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.BL.Models.Note;

namespace Theater.BL.Services
{
    public interface INoteService
    {
        Task<NoteDto> GetNoteAsync(Guid id);

        Task<NoteDto> GetNoteByNameAsync(string name);

        Task<IEnumerable<NoteDto>> GetAllNotesAsync();

        Task<NoteDto> AddNoteAsync(NoteCreateUpdateDto noteDtoToAdd);

        Task<NoteDto> UpdateNoteAsync(Guid id, NoteCreateUpdateDto noteDtoPayload);

        Task<NoteDto> DeleteNoteAsync(Guid id);
    }
}
