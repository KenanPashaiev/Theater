using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.Models;

namespace Theater.DAL.Abstractions
{
    public interface INoteRepository
    {
        Task<Note> GetNoteAsync(Guid id);

        Task<Note> GetNoteByNameAsync(string name);

        Task<IEnumerable<Note>> GetAllNotesAsync();

        Task<Note> AddNoteAsync(Note entity);

        Task<Note> UpdateNoteAsync(Guid id, Note entity);

        Task<Note> DeleteNoteAsync(Guid id);
    }
}
