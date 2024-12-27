using Application.DTOs.NotesDTOs.AddNote;
using Application.DTOs.NotesDTOs.GetNotesByApiKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface INotes
    {
        Task<AddNoteResponse> AddNoteAsync(AddNoteDTO addNoteDTO);

        Task<GetNotesByApiKeyResponse> GetNotesByApiKeyAsync(GetNotesByApiKeyDTO getNotesByApiKeyDTO);
    }
}
