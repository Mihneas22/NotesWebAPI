using Application.DTOs.NotesDTOs.AddNote;
using Application.DTOs.NotesDTOs.DeleteNote;
using Application.DTOs.NotesDTOs.GetNotesByApiKey;
using Application.DTOs.NotesDTOs.GetNotesByTags;
using Application.DTOs.NotesDTOs.ModifyNote;
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

        Task<GetNotesByTagsResponse> GetNotesByTagsAsync(GetNotesByTagsDTO getNotesByTagsDTO);
        
        Task<ModifyNoteResponse> ModifyNotesAsync(ModifyNoteDTO modifyNoteDTO);

        Task<DeleteNoteResponse> DeleteNoteAsync(DeleteNoteDTO deleteNoteDTO);
    }
}
