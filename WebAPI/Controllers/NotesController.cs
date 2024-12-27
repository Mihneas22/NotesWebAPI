using Application.DTOs.NotesDTOs.AddNote;
using Application.DTOs.NotesDTOs.GetNotesByApiKey;
using Application.Repository;
using Domain.Entities.Keys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController: ControllerBase
    {
        private readonly INotes notesRepository;

        public NotesController(INotes notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        //GET
        [HttpGet("{apiKey}/getNotes")]
        public async Task<ActionResult<GetNotesByApiKeyResponse>> GetNotesByKeyAsync(string apiKey)
        {
            var result = await notesRepository.GetNotesByApiKeyAsync(new GetNotesByApiKeyDTO { ApiKey = apiKey });
            return Ok(result);
        }

        //POST
        [HttpPost("{apiKey}/addNote")]
        public async Task<ActionResult<AddNoteResponse>> AddNotesAsync(string apiKey,AddNoteDTO addNoteDTO)
        {
            addNoteDTO.ApiKey = apiKey;
            var result = await notesRepository.AddNoteAsync(addNoteDTO);
            return Ok(result);
        }
    }
}
