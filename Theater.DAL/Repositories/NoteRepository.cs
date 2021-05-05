using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.DAL.Abstractions;
using Theater.Models;

namespace Theater.DAL.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationContext applicationContext;

        public NoteRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<Note> GetNoteAsync(Guid id)
        {
            return await applicationContext.Notes.
                SingleOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Note> GetNoteByNameAsync(string name)
        {
            return await applicationContext.Notes.
                SingleOrDefaultAsync(n => n.Name == name);
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            return await applicationContext.Notes.ToArrayAsync();
        }

        public async Task<Note> AddNoteAsync(Note entity)
        {
            var note = await applicationContext.Notes.AddAsync(entity);
            applicationContext.SaveChanges();
            return await GetNoteAsync(note.Entity.Id);
        }

        public async Task<Note> UpdateNoteAsync(Guid id, Note entity)
        {
            var note = await applicationContext.Notes.SingleOrDefaultAsync(n => n.Id == id);
            note.Name = entity.Name;
            note.Text = entity.Text;
            applicationContext.SaveChanges();
            return note;
        }

        public async Task<Note> DeleteNoteAsync(Guid id)
        {
            var note = await GetNoteAsync(id);
            applicationContext.Notes.Remove(note);
            applicationContext.SaveChanges();
            return note;
        }
    }
}
