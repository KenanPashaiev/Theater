using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.BL.Models.Note;
using Theater.DAL.Abstractions;
using Theater.Models;

namespace Theater.BL.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteRepository;
        private readonly IMapper mapper;

        public NoteService(INoteRepository noteRepository, IMapper mapper)
        {
            this.noteRepository = noteRepository;
            this.mapper = mapper;
        }

        public async Task<NoteDto> GetNoteAsync(Guid id)
        {
            var note = await noteRepository.GetNoteAsync(id);
            return mapper.Map<NoteDto>(note);
        }

        public async Task<NoteDto> GetNoteByNameAsync(string name)
        {
            var note = await noteRepository.GetNoteByNameAsync(name);
            return mapper.Map<NoteDto>(note);
        }

        public async Task<IEnumerable<NoteDto>> GetAllNotesAsync()
        {
            var notes = await noteRepository.GetAllNotesAsync();
            return mapper.Map<IEnumerable<NoteDto>>(notes);
        }

        public async Task<NoteDto> AddNoteAsync(NoteCreateUpdateDto noteDtoToAdd)
        {
            var noteToAdd = mapper.Map<Note>(noteDtoToAdd);
            var addedNote = await noteRepository.AddNoteAsync(noteToAdd);
            return mapper.Map<NoteDto>(addedNote);
        }

        public async Task<NoteDto> UpdateNoteAsync(Guid id, NoteCreateUpdateDto noteDtoPayload)
        {
            var notePayload = mapper.Map<Note>(noteDtoPayload);
            var updatedNote = await noteRepository.UpdateNoteAsync(id, notePayload);
            return mapper.Map<NoteDto>(updatedNote);
        }

        public async Task<NoteDto> DeleteNoteAsync(Guid id)
        {
            var note = await noteRepository.DeleteNoteAsync(id);
            return mapper.Map<NoteDto>(note);
        }
    }
}
