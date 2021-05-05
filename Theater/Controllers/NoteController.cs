using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Theater.BL.Models.Note;
using Theater.BL.Services;
using Theater.Models;

namespace Theater.Controllers
{
    [ApiController]
    [Route("Note")]
    [Authorize(Roles = "Admin")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService noteService;

        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        /// <summary>
        /// Gets Note by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNote([FromRoute]Guid id)
        {
            var note = await noteService.GetNoteAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        /// <summary>
        /// Gets Note by name
        /// </summary>
        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetNoteByName([FromRoute] string name)
        {
            var note = await noteService.GetNoteByNameAsync(name);
            if(note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        /// <summary>
        /// Gets all Notes
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var notes = await noteService.GetAllNotesAsync();
            return Ok(notes);
        }

        /// <summary> ///(Roles = "Client")
        /// Adds Note
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddNote(NoteCreateUpdateDto noteCreateUpdateDto)
        {
            var notes = await noteService.AddNoteAsync(noteCreateUpdateDto);
            return Ok(notes);
        }

        /// <summary>
        /// Updates Note by id
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(Guid id, NoteCreateUpdateDto noteCreateUpdateDto)
        {
            var existingNote = await noteService.GetNoteAsync(id);
            if (existingNote == null)
            {
                return NotFound();
            }

            var notes = await noteService.UpdateNoteAsync(id, noteCreateUpdateDto);
            return Ok(notes);
        }

        /// <summary>
        /// Deletes Note by id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            var existingNote = await noteService.GetNoteAsync(id);
            if (existingNote == null)
            {
                return NotFound();
            }

            var notes = await noteService.DeleteNoteAsync(id);
            return Ok(notes);
        }
    }
}
